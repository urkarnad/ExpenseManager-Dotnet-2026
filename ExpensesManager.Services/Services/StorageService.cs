using ExpensesManager.Services.Storage;
using ExpensesManager.Storage.Entities;

namespace ExpensesManager.Services.Services;

public class StorageService
{
    public IReadOnlyCollection<WalletStorageModel> GetWallets() 
        => FakeStorage.Wallets.AsReadOnly();
    
    public IReadOnlyCollection<TransactionStorageModel> GetTransactions()
        => FakeStorage.Transactions.AsReadOnly();
}