using ExpensesManager.Storage.Enums;

namespace ExpensesManager.Storage.Entities;

public class TransactionStorageModel
{
    public Guid Id { get; set; }
    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public TransactionCategory Category { get; set; }
    public string Description { get; set; } = "";
    public DateTime Date { get; }

    public TransactionStorageModel() { }

    public TransactionStorageModel(Guid id, Guid walletId, decimal amount, TransactionCategory category,
        string description, DateTime date)
    {
        Id = id;
        WalletId = walletId;
        Amount = amount;
        Category = category;
        Description = description;
        Date = date;
    }
}