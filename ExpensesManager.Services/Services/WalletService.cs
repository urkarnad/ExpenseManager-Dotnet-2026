using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;
using ExpensesManager.Storage.Interfaces;
using ExpensesManager.Storage.Repositories;

namespace ExpensesManager.Services.Services;

public class WalletService : IWalletService
{
    private readonly IWalletRepository _walletRepo;
    private readonly ITransactionRepository _transactionRepo;

    public WalletService(
        IWalletRepository walletRepo,
        ITransactionRepository transactionRepo)
    {
        _walletRepo = walletRepo;
        _transactionRepo = transactionRepo;
    }

    public IEnumerable<WalletListDto> GetAll()
    {
        return _walletRepo.GetAll()
            .Select(w => new WalletListDto
            {
                Id = w.Id,
                Name = w.Name
            });
    }

    public WalletDetailsDto GetById(Guid id)
    {
        var wallet = _walletRepo.GetById(id);
        var transactions = _transactionRepo.GetByWalletId(id);

        var amount = transactions.Sum(t => t.Amount);

        return new WalletDetailsDto
        {
            Id = wallet.Id,
            Name = wallet.Name,
            Amount = amount,
            Transactions = transactions.Select(t => new TransactionListDto
            {
                Id = t.Id,
                Amount = t.Amount
            }).ToList()
        };
    }
}