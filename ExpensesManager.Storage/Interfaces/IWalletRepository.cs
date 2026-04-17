using ExpensesManager.Storage.Entities;

namespace ExpensesManager.Storage.Interfaces
{
    public interface IWalletRepository
    {
        Task<List<WalletStorageModel>> GetAllAsync();
        Task<WalletStorageModel?> GetByIdAsync(Guid id);
        Task AddAsync(WalletStorageModel wallet);
        Task UpdateAsync(WalletStorageModel wallet);
        Task DeleteAsync(Guid id);
        Task<bool> IsEmptyAsync();
    }
}
