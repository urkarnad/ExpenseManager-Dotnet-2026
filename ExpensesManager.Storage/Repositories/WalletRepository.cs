using ExpensesManager.Storage.Database;
using ExpensesManager.Storage.Entities;
using ExpensesManager.Storage.Interfaces;
using ExpensesManager.Storage.Storage;

namespace ExpensesManager.Storage.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly JsonStorage _storage;

    public WalletRepository(JsonStorage storage)
    {
        _storage = storage;
    }

    public async Task<List<WalletStorageModel>> GetAllAsync()
        => await _storage.ReadWalletsAsync();

    public async Task<WalletStorageModel?> GetByIdAsync(Guid id)
    {
        var all = await _storage.ReadWalletsAsync();
        return all.FirstOrDefault(w => w.Id == id);
    }

    public async Task AddAsync(WalletStorageModel wallet)
    {
        var all = await _storage.ReadWalletsAsync();
        all.Add(wallet);
        await _storage.WriteWalletsAsync(all);
    }

    public async Task UpdateAsync(WalletStorageModel wallet)
    {
        var all = await _storage.ReadWalletsAsync();
        var index = all.FindIndex(w => w.Id == wallet.Id);
        if (index >= 0)
        {
            all[index] = wallet;
            await _storage.WriteWalletsAsync(all);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var all = await _storage.ReadWalletsAsync();
        all.RemoveAll(w => w.Id == id);
        await _storage.WriteWalletsAsync(all);
    }

    public async Task<bool> IsEmptyAsync()
    {
        var all = await _storage.ReadWalletsAsync();
        return all.Count == 0;
    }
}