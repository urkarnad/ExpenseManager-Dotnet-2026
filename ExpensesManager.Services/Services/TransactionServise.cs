using ExpensesManager.Storage.Entities;
using ExpensesManager.Services.Storage;

namespace ExpensesManager.Services.Services;

public class TransactionService
{
    public IEnumerable<Transaction> GetTransactionsByWalletId(Guid walletId)
    {
        var wallet = FakeStorage.Wallets.FirstOrDefault(w => w.Id == walletId);
        
        return wallet?.Transactions ?? Enumerable.Empty<Transaction>();
    }

    public Transaction? GetTransactionById(Guid transactionId)
    {
        return FakeStorage.Wallets.SelectMany(w => w.Transactions)
            .FirstOrDefault(t => t.Id == transactionId);
    }

    public void AddTransaction(Guid walletId, Transaction transaction)
    {
        var wallet = FakeStorage.Wallets.FirstOrDefault(w => w.Id == walletId);

        if (wallet != null)
        {
            wallet.AddTransaction(transaction);
        }
    }
}