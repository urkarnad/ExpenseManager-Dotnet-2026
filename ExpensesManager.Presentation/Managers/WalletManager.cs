using ExpensesManager.Services.Services;
using ExpensesManager.Domain.Models;

namespace ExpensesManager.Presentation.Managers;

public class WalletManager
{
    private readonly WalletService _walletService;

    public WalletManager(WalletService walletService)
    {
        _walletService = walletService;
    }

    public IReadOnlyCollection<Wallet> GetAllWallets()
    {
        return _walletService.GetAllWallets().ToList().AsReadOnly();
    }

    public Wallet? GetWalletById(Guid id)
    {
        return _walletService.GetAllWallets().FirstOrDefault(wallet => wallet.Id == id);
    }
}