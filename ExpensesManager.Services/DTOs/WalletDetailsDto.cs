using ExpensesManager.Storage.Enums;

namespace ExpensesManager.Services.DTOs;

public class WalletDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
    public List<TransactionListDto> Transactions { get; set; } = new();
}