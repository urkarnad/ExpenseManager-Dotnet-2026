// показувати всі транзакції конкретного гаманця
// показувати деталі конкретної транзакції

using ExpensesManager.Services.Services;
using ExpensesManager.Storage.Entities;

namespace ExpensesManager.Presentation.Managers;

public class TransactionManager
{
    private readonly TransactionService _transactionService;
    
    public TransactionManager(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public void ShowTransaction(Guid walletId)
    {
        var transactions = _transactionService.GetTransactionsByWalletId(walletId);

        foreach (var transaction in transactions)
        {
            Console.WriteLine($"{transaction.Id} - {transaction.Date:g} - " +
                              $"{transaction.Amount} - {transaction.Category} - {transaction.Description}");
        }
    }

    public void ShowTransactionDetails(Guid transactionId)
    {
        var transaction = _transactionService.GetTransactionById(transactionId);

        if (transaction == null)
        {
            Console.WriteLine("No transaction found.");
            return;
        }
        
        Console.WriteLine("Transaction details:");
        Console.WriteLine($"Amount: {transaction.Amount}");
        Console.WriteLine($"Category: {transaction.Category}");
        Console.WriteLine($"Description: {transaction.Description}");
        Console.WriteLine($"Date: {transaction.Date}");
    }
}
// TransactionManager → TransactionService → FakeStorage