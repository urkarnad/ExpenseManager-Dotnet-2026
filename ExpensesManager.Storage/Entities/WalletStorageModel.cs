using ExpensesManager.Storage.Enums;

namespace ExpensesManager.Storage.Entities;

public class WalletStorageModel
{
    public Guid Id { get; }
    public string Name { get; set; }
    public Currency Currency { get; set; }
    
    public WalletStorageModel(Guid id, string name, Currency currency)
    {
        Id = id;
        Name = name;
        Currency = currency;
    }
}
