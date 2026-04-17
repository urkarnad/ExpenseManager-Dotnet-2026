using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;
using ExpensesManager.Storage.Entities;
using ExpensesManager.Storage.Enums;
using ExpensesManager.Storage.Interfaces;

namespace ExpensesManager.Services.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepo;
    private readonly ITransactionRepository _transactionRepo;

    public WalletService(IWalletRepository walletRepo, ITransactionRepository transactionRepo)
    {
        _walletRepo = walletRepo;
        _transactionRepo = transactionRepo;
    }

    public async Task<IEnumerable<WalletListDto>> GetAllAsync()
    {
        var wallets = await _walletRepo.GetAllAsync();
        return wallets.Select(w => new WalletListDto { Id = w.Id, Name = w.Name });
    }

    public async Task<WalletDetailsDto> GetByIdAsync(Guid id)
    {
        var wallet = await _walletRepo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Wallet {id} not found");
        var transactions = await _transactionRepo.GetByWalletIdAsync(id);

        return new WalletDetailsDto
        {
            Id = wallet.Id,
            Name = wallet.Name,
            Currency = wallet.Currency,
            Amount = transactions.Sum(t => t.Amount),
            Transactions = transactions.Select(t => new TransactionListDto
            {
                Id = t.Id,
                Amount = t.Amount,
                Description = t.Description,
                Category = t.Category,
                Date = t.Date
            }).ToList()
        };
    }

    public async Task<WalletListDto> AddAsync(string name, Currency currency)
    {
        var wallet = new WalletStorageModel(Guid.NewGuid(), name, currency);
        await _walletRepo.AddAsync(wallet);
        return new WalletListDto { Id = wallet.Id, Name = wallet.Name };
    }

    public async Task UpdateAsync(Guid id, string name, Currency currency)
    {
        var wallet = await _walletRepo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Wallet {id} not found");
        wallet.Name = name;
        wallet.Currency = currency;
        await _walletRepo.UpdateAsync(wallet);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _transactionRepo.DeleteByWalletIdAsync(id);
        await _walletRepo.DeleteAsync(id);
    }
}