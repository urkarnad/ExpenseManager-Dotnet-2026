using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;
using ExpensesManager.Storage.Entities;
using ExpensesManager.Storage.Enums;
using ExpensesManager.Storage.Interfaces;

namespace ExpensesManager.Services.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repo;

    public TransactionService(ITransactionRepository repo)
    {
        _repo = repo;
    }

    public async Task<TransactionDetailsDto> GetByIdAsync(Guid id)
    {
        var t = await _repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Transaction {id} not found");

        return new TransactionDetailsDto
        {
            Id = t.Id,
            WalletId = t.WalletId,
            Amount = t.Amount,
            Category = t.Category,
            Description = t.Description,
            Date = t.Date
        };
    }

    public async Task<TransactionListDto> AddAsync(Guid walletId, decimal amount,
        TransactionCategory category, string description)
    {
        var t = new TransactionStorageModel(Guid.NewGuid(), walletId, amount, category, description, DateTime.Now);
        await _repo.AddAsync(t);
        return new TransactionListDto
        {
            Id = t.Id,
            Amount = t.Amount,
            Description = t.Description,
            Category = t.Category,
            Date = t.Date
        };
    }

    public async Task UpdateAsync(Guid id, decimal amount, TransactionCategory category, string description)
    {
        var t = await _repo.GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"Transaction {id} not found");
        t.Amount = amount;
        t.Category = category;
        t.Description = description;
        await _repo.UpdateAsync(t);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
    }
}