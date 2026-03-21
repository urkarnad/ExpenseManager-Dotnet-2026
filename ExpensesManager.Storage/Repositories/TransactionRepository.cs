using ExpensesManager.Storage.Entities;
using ExpensesManager.Services.Storage;
using ExpensesManager.Storage.Interfaces;

namespace ExpensesManager.Storage.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FakeStorage _storage;

        public TransactionRepository(FakeStorage storage)
        {
            _storage = storage;
        }

        public List<TransactionStorageModel> GetByWalletId(Guid walletId)
            => _storage.Transactions.Where(x => x.WalletId == walletId).ToList();

        public TransactionStorageModel GetById(Guid id)
            => _storage.Transactions.FirstOrDefault(x => x.Id == id);
    }
}
