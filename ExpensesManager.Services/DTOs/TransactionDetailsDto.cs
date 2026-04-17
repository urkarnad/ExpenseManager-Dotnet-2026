using ExpensesManager.Storage.Enums;

namespace ExpensesManager.Services.DTOs;

public class TransactionDetailsDto
{
    public Guid Id { get; set; }
    public Guid WalletId { get; set; }
    public decimal Amount { get; set; }
    public TransactionCategory Category { get; set; }
    public string Description { get; set; } = "";
    public DateTime Date { get; set; }
}