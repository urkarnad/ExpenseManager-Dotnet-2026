using ExpensesManager.Storage.Entities;
using ExpensesManager.Storage.Enums;
using ExpensesManager.Storage.Interfaces;

namespace ExpensesManager.Storage.Storage;

public class DatabaseSeeder
{
    private readonly IWalletRepository _walletRepo;
    private readonly ITransactionRepository _transactionRepo;

    public DatabaseSeeder(IWalletRepository walletRepo, ITransactionRepository transactionRepo)
    {
        _walletRepo = walletRepo;
        _transactionRepo = transactionRepo;
    }

    public async Task SeedIfEmptyAsync()
    {
        if (!await _walletRepo.IsEmptyAsync())
            return;

        var mono = new WalletStorageModel(Guid.NewGuid(), "Monobank Card", Currency.UAH);
        var privat = new WalletStorageModel(Guid.NewGuid(), "PrivatBank Card", Currency.EUR);
        var dora = new WalletStorageModel(Guid.NewGuid(), "Dora Wallet", Currency.GBP);

        await _walletRepo.AddAsync(mono);
        await _walletRepo.AddAsync(privat);
        await _walletRepo.AddAsync(dora);

        var monoTransactions = new[]
        {
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, -1000, TransactionCategory.Clothing, "Bershka", DateTime.Now),
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, 40000, TransactionCategory.Other, "Salary", DateTime.Now.AddDays(-4)),
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, -100, TransactionCategory.Restaurants, "Blur", DateTime.Now.AddDays(-3)),
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, -10000, TransactionCategory.Medicine, "Dentist", DateTime.Now),
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, 2000, TransactionCategory.Other, "Scholarship", DateTime.Now),
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, 1000, TransactionCategory.Other, "Mama dopomohla", DateTime.Now.AddDays(-2)),
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, 50000, TransactionCategory.Other, "V tumbochke znaishla", DateTime.Now.AddDays(-1)),
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, -15000, TransactionCategory.Clothing, "SecondHand", DateTime.Now),
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, -250, TransactionCategory.Transportation, "Bus pass", DateTime.Now.AddDays(-6)),
            new TransactionStorageModel(Guid.NewGuid(), mono.Id, -1000, TransactionCategory.Entertainment, "Cinema Avatar", DateTime.Now),
        };

        var privatTransactions = new[]
        {
            new TransactionStorageModel(Guid.NewGuid(), privat.Id, 50000, TransactionCategory.Other, "Kolomoisky dav", DateTime.Now.AddDays(-10)),
            new TransactionStorageModel(Guid.NewGuid(), privat.Id, -3, TransactionCategory.Restaurants, "Kava", DateTime.Now.AddDays(-10)),
            new TransactionStorageModel(Guid.NewGuid(), privat.Id, -10, TransactionCategory.Transportation, "Taxy to the kava", DateTime.Now.AddDays(-10)),
            new TransactionStorageModel(Guid.NewGuid(), privat.Id, 500, TransactionCategory.Other, "Salary", DateTime.Now.AddDays(-5)),
        };

        foreach (var t in monoTransactions)
            await _transactionRepo.AddAsync(t);

        foreach (var t in privatTransactions)
            await _transactionRepo.AddAsync(t);
    }
}