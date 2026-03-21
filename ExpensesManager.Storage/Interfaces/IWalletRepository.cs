using ExpensesManager.Storage.Entities;

namespace ExpensesManager.Storage.Interfaces
{
    public interface IWalletRepository
    {
        List<WalletStorageModel> GetAll();
        WalletStorageModel GetById(Guid id);
    }
}
