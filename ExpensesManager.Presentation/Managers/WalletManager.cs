using ExpensesManager.Services.Services;

namespace ExpensesManager.Presentation.Managers;

public class WalletManager
{
    private readonly WalletService _walletService;
    
    public WalletManager(WalletService walletService)
    {
        _walletService = walletService;
    }

    public void ShowAllWallets()
    {
        var wallets = _walletService.GetAllWallets();

        foreach (var wallet in wallets)
        {
            Console.WriteLine($"{wallet.Id} - {wallet.Name} | {wallet.Currency} | Balance: {wallet.TotalAmount} {wallet.Currency}");
        }
    }

    public void ShowWalletDetails(Guid walletId)
    {
        var wallet = _walletService.GetWalletById(walletId);

        if (wallet == null)
        {
            Console.WriteLine("Wallet not found.");
            return;
        }
        
        Console.WriteLine($"Name: {wallet.Name} | {wallet.Currency} | Total amount: {wallet.TotalAmount} {wallet.Currency}");
        // Console.WriteLine($"Transactions: ");
        //
        // foreach (var transaction in wallet.Transactions)
        // {
        //     Console.WriteLine($"{transaction.Date} | {transaction.Amount} | " +
        //                       $"{transaction.Category} | {transaction.Description}");
        // }
    }
}