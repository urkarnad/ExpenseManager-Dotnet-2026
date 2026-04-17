using ExpensesManager.Services.DTOs;
using ExpensesManager.Storage.Enums;

namespace ExpensesManager.Services.Interfaces;

public interface ITransactionService
{
    Task<TransactionDetailsDto> GetByIdAsync(Guid id);
    Task<TransactionListDto> AddAsync(Guid walletId, decimal amount, TransactionCategory category, string description);
    Task UpdateAsync(Guid id, decimal amount, TransactionCategory category, string description);
    Task DeleteAsync(Guid id);
}