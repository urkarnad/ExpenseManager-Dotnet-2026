using ExpensesManager.Storage.Enums;

namespace ExpensesManager.Storage.Entities;

public class Transaction
{
    public Guid Id { get; }
    public Guid WalletId { get; }
    public decimal Amount { get; set; }
    public TransactionCategory Category { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; }
    public bool IsExpense => Amount < 0;

    public Transaction(Guid walletId, decimal amount, TransactionCategory category,
        string description, DateTime date)
    {
        Id = Guid.NewGuid();
        WalletId = walletId;
        Amount = amount;
        Category = category;
        Description = description;
        Date = date;
    }
}
