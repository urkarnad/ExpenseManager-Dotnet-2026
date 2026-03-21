using ExpensesManager.Storage.Entities;

namespace ExpensesManager.Storage.Interfaces
{
    public interface ITransactionRepository
    {
        List<TransactionStorageModel> GetByWalletId(Guid walletId);
        TransactionStorageModel GetById(Guid id);
    }
}
