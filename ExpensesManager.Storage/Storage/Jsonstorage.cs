using System.Text.Json;
using ExpensesManager.Storage.Entities;

namespace ExpensesManager.Storage.Database;

public class JsonStorage
{
    private readonly string _walletsPath;
    private readonly string _transactionsPath;

    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true
    };

    public JsonStorage(string dataDirectory)
    {
        Directory.CreateDirectory(dataDirectory);
        _walletsPath = Path.Combine(dataDirectory, "wallets.json");
        _transactionsPath = Path.Combine(dataDirectory, "transactions.json");
    }

    public async Task<List<WalletStorageModel>> ReadWalletsAsync()
    {
        if (!File.Exists(_walletsPath)) return new();
        var json = await File.ReadAllTextAsync(_walletsPath);
        return JsonSerializer.Deserialize<List<WalletStorageModel>>(json, Options) ?? new();
    }

    public async Task WriteWalletsAsync(List<WalletStorageModel> wallets)
    {
        var json = JsonSerializer.Serialize(wallets, Options);
        await File.WriteAllTextAsync(_walletsPath, json);
    }

    public async Task<List<TransactionStorageModel>> ReadTransactionsAsync()
    {
        if (!File.Exists(_transactionsPath)) return new();
        var json = await File.ReadAllTextAsync(_transactionsPath);
        return JsonSerializer.Deserialize<List<TransactionStorageModel>>(json, Options) ?? new();
    }

    public async Task WriteTransactionsAsync(List<TransactionStorageModel> transactions)
    {
        var json = JsonSerializer.Serialize(transactions, Options);
        await File.WriteAllTextAsync(_transactionsPath, json);
    }
}