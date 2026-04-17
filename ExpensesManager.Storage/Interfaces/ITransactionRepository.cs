using ExpensesManager.Storage.Entities;

namespace ExpensesManager.Storage.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<TransactionStorageModel>> GetByWalletIdAsync(Guid walletId);
        Task<TransactionStorageModel?> GetByIdAsync(Guid id);
        Task AddAsync(TransactionStorageModel transaction);
        Task UpdateAsync(TransactionStorageModel transaction);
        Task DeleteAsync(Guid id);
        Task DeleteByWalletIdAsync(Guid walletId);
    }
}
