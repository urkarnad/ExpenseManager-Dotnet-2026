using ExpensesManager.Services.DTOs;

namespace ExpensesManager.Services.Interfaces;

public interface ITransactionService
{
    TransactionDetailsDto GetById(Guid id);
}