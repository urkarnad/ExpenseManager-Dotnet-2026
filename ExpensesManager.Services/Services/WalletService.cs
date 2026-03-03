using ExpensesManager.Domain.Models;

namespace ExpensesManager.Services.Services;

public class WalletService
{
    private readonly StorageService _storage;

    public WalletService(StorageService storage)
    {
        _storage = storage;
    }

    public IEnumerable<Wallet> GetAllWallets()
    {
        var wallets = _storage.GetWallets();
        var transactions = _storage.GetTransactions();
        
        return wallets.Select(w =>
        {
            var walletTransactions = transactions
                .Where(t => t.WalletId == w.Id)
                .Select(t => new Transaction(
                    t.Id,
                    t.WalletId,
                    t.Amount,
                    t.Category,
                    t.Description,
                    t.Date));

            return new Wallet(
                w.Id,
                w.Name,
                w.Currency, 
                walletTransactions);
        });
    }
}
