using ExpensesManager.Storage.Enums;

namespace ExpensesManager.Storage.Entities;

public class Wallet
{
    public Guid Id { get;}
    public string Name { get; set; }
    public Currency Currency { get; set; }
    private readonly List<Transaction> _transactions; // Inside Transactions list
    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly(); // Safe access to the Transactions
    // Total sum (calculated field)
    public decimal TotalAmount => _transactions.Sum(t => t.Amount);

    public Wallet(string name, Currency currency)
    {
        Id = Guid.NewGuid();
        Name = name;
        Currency = currency;
        _transactions = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }
}
