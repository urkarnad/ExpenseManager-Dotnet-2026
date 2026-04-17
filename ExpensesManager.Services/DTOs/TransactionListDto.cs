using ExpensesManager.Storage.Enums;

namespace ExpensesManager.Services.DTOs;

public class TransactionListDto
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = "";
    public TransactionCategory Category { get; set; }
    public DateTime Date { get; set; }
}