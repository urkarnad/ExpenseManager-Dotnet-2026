using ExpensesManager.Domain.Models;

namespace ExpensesManager.Services.Services;

public class TransactionService
{
    private readonly StorageService _storage;

    public TransactionService(StorageService storage)
    {
        _storage = storage;
    }

    public IEnumerable<Transaction> GetByWalletId(Guid walletId)
    {
        return _storage.GetTransactions()
            .Where(t => t.WalletId == walletId)
            .Select(t => new Transaction(
                t.Id,
                t.WalletId,
                t.Amount,
                t.Category,
                t.Description,
                t.Date));
    }
}