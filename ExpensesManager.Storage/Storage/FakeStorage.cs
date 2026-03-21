using ExpensesManager.Storage.Enums;
using ExpensesManager.Storage.Entities;

namespace ExpensesManager.Services.Storage;

public class FakeStorage
{
    public List<WalletStorageModel> Wallets { get; }
    public List<TransactionStorageModel> Transactions { get; }

    public FakeStorage()
    {
        Wallets = new List<WalletStorageModel>();
        Transactions = new List<TransactionStorageModel>();
        
        // Creating Wallets
        var monoWallet = new WalletStorageModel(Guid.NewGuid(),"Monobank Card", Currency.UAH);
        var privatWallet = new WalletStorageModel(Guid.NewGuid(),"PrivatBank Card", Currency.EUR);
        var doraWallet = new WalletStorageModel(Guid.NewGuid(),"Dora Wallet", Currency.GBP);
        
        Wallets.Add(monoWallet);
        Wallets.Add(privatWallet);
        Wallets.Add(doraWallet);
        
        // Add Transactions
        // monoWallet
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, -1000,
            TransactionCategory.Clothing, "Bershka", DateTime.Now));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, 40000, 
            TransactionCategory.Other, "Salary", DateTime.Now.AddDays(-4)));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, -100, 
            TransactionCategory.Restaurants, "Blur", DateTime.Now.AddDays(-3)));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, -10000, 
            TransactionCategory.Medicine, "Dentist", DateTime.Now));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, 2000, 
            TransactionCategory.Other, "Scholarship", DateTime.Now));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, 1000, 
            TransactionCategory.Other, "Mama dopomohla", DateTime.Now.AddDays(-2)));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, 50000, 
            TransactionCategory.Other, "V tumbochke znaishla", DateTime.Now.AddDays(-1)));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, -15000, 
            TransactionCategory.Clothing, "SecondHand", DateTime.Now));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, -250, 
            TransactionCategory.Transportation, "Bus pass", DateTime.Now.AddDays(-6)));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), monoWallet.Id, -1000, 
            TransactionCategory.Entertainment, "Cinema Avatar", DateTime.Now));
        
        // privatWalllet
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), privatWallet.Id, 50000, 
            TransactionCategory.Other, "Kolomoisky dav", DateTime.Now.AddDays(-10)));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), privatWallet.Id, -3, 
            TransactionCategory.Restaurants, "Kava", DateTime.Now.AddDays(-10)));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), privatWallet.Id, -10, 
            TransactionCategory.Transportation, "Taxy to the kava", DateTime.Now.AddDays(-10)));
        Transactions.Add(new TransactionStorageModel(Guid.NewGuid(), privatWallet.Id, 500, 
            TransactionCategory.Other, "Salary", DateTime.Now.AddDays(-5)));
        
        // doraWallet is empty
    }
}