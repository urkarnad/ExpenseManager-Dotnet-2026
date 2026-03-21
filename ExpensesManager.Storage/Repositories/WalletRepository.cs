using ExpensesManager.Storage.Entities;
using ExpensesManager.Services.Storage;
using ExpensesManager.Storage.Interfaces;

namespace ExpensesManager.Storage.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly FakeStorage _storage;

        public WalletRepository(FakeStorage storage)
        {
            _storage = storage;
        }

        public List<WalletStorageModel> GetAll()
            => _storage.Wallets;

        public WalletStorageModel GetById(Guid id)
            => _storage.Wallets.FirstOrDefault(x => x.Id == id);
    }
}
