using ExpensesManager.Services.Services;
using ExpensesManager.Domain.Models;

namespace ExpensesManager.Presentation.Managers;

public class TransactionManager
{
    private readonly TransactionService _transactionService;
    
    public TransactionManager(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public IReadOnlyCollection<Transaction> GetTransactionsByWalletId(Guid walletId)
    {
        return _transactionService.GetByWalletId(walletId).ToList().AsReadOnly();
    }
    
}