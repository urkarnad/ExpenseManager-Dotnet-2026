using ExpensesManager.Storage.Database;
using ExpensesManager.Storage.Entities;
using ExpensesManager.Storage.Interfaces;
using ExpensesManager.Storage.Storage;

namespace ExpensesManager.Storage.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly JsonStorage _storage;

    public TransactionRepository(JsonStorage storage)
    {
        _storage = storage;
    }

    public async Task<List<TransactionStorageModel>> GetByWalletIdAsync(Guid walletId)
    {
        var all = await _storage.ReadTransactionsAsync();
        return all.Where(t => t.WalletId == walletId).ToList();
    }

    public async Task<TransactionStorageModel?> GetByIdAsync(Guid id)
    {
        var all = await _storage.ReadTransactionsAsync();
        return all.FirstOrDefault(t => t.Id == id);
    }

    public async Task AddAsync(TransactionStorageModel transaction)
    {
        var all = await _storage.ReadTransactionsAsync();
        all.Add(transaction);
        await _storage.WriteTransactionsAsync(all);
    }

    public async Task UpdateAsync(TransactionStorageModel transaction)
    {
        var all = await _storage.ReadTransactionsAsync();
        var index = all.FindIndex(t => t.Id == transaction.Id);
        if (index >= 0)
        {
            all[index] = transaction;
            await _storage.WriteTransactionsAsync(all);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var all = await _storage.ReadTransactionsAsync();
        all.RemoveAll(t => t.Id == id);
        await _storage.WriteTransactionsAsync(all);
    }

    public async Task DeleteByWalletIdAsync(Guid walletId)
    {
        var all = await _storage.ReadTransactionsAsync();
        all.RemoveAll(t => t.WalletId == walletId);
        await _storage.WriteTransactionsAsync(all);
    }
}