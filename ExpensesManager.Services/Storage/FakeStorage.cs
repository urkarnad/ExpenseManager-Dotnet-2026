using ExpensesManager.Storage.Enums;
using ExpensesManager.Storage.Entities;

namespace ExpensesManager.Services.Storage;

internal static class FakeStorage
{
    public static List<Wallet> Wallets { get; }

    static FakeStorage()
    {
        Wallets = new List<Wallet>();
        
        // Creating Wallets
        var monoWallet = new Wallet("Monobank Card", Currency.UAH);
        var privatWallet = new Wallet("PrivatBank Card", Currency.EUR);
        var senseWallet = new Wallet("Sense Bank Wallet", Currency.JPY);
        var doraWallet = new Wallet("Dora Wallet", Currency.GBP);
        
        // Add Transactions
        monoWallet.AddTransaction(new Transaction(
                    monoWallet.Id, -67, TransactionCategory.Food, "Coffee", DateTime.Now));
        monoWallet.AddTransaction(new Transaction(
                    monoWallet.Id, 2000, TransactionCategory.Other, "Scholarship", DateTime.Now.AddDays(-10)));
        
        privatWallet.AddTransaction(new Transaction(
                    privatWallet.Id, -400, TransactionCategory.Medicine, "Dentist", DateTime.Now.AddDays(-7)));
        privatWallet.AddTransaction(new Transaction(
                    privatWallet.Id, -15, TransactionCategory.Clothing, "T-Shirt", DateTime.Now.AddDays(-3)));
        
        senseWallet.AddTransaction(new Transaction(
                    senseWallet.Id, -500, TransactionCategory.Entertainment, "Museum", DateTime.Now));
        senseWallet.AddTransaction(new Transaction(
                    senseWallet.Id, 300000, TransactionCategory.Other, "Salary", DateTime.Now.AddDays(-1)));
        
        Wallets.Add(monoWallet);
        Wallets.Add(privatWallet);
        Wallets.Add(senseWallet);
        Wallets.Add(doraWallet); // Empty Wallet
    }
}