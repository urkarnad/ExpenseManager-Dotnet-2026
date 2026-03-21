using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;
using ExpensesManager.Storage.Interfaces;
using ExpensesManager.Storage.Repositories;

namespace ExpensesManager.Services.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repo;

    public TransactionService(ITransactionRepository repo)
    {
        _repo = repo;
    }

    public TransactionDetailsDto GetById(Guid id)
    {
        var t = _repo.GetById(id);

        return new TransactionDetailsDto
        {
            Id = t.Id,
            Amount = t.Amount,
            Category = t.Category,
            Description = t.Description,
            Date = t.Date
        };
    }
}