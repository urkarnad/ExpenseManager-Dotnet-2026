using ExpensesManager.Domain.Models;
using ExpensesManager.Presentation.Managers;
using ExpensesManager.Services.Services;

namespace ExpensesManager.ConsoleApp;

class Program
{
    static void Main()
    {
        var storageService = new StorageService();
        var walletService = new WalletService(storageService);
        var transactionService = new TransactionService(storageService);

        var walletManager = new WalletManager(walletService);
        var transactionManager = new TransactionManager(transactionService);

        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("WALLET LIST\n");

            var wallets = walletManager.GetAllWallets().ToList();

            for (int i = 0; i < wallets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {wallets[i].Name} | {wallets[i].Currency} | Balance: {wallets[i].TotalAmount}");
                Console.WriteLine();
            }

            Console.WriteLine("Enter index to view details or 0 to exit:");
            var input = Console.ReadLine();

            if (input == "0")
            {
                exit = true;
                continue;
            }

            if (!int.TryParse(input, out int index) || index < 1 || index > wallets.Count)
            {
                Console.WriteLine("Invalid index.");
                Console.ReadKey();
                continue;
            }

            var selectedWallet = wallets[index - 1];
            var walletId = selectedWallet.Id;

            if (selectedWallet == null)
            {
                Console.WriteLine("Wallet not found.");
                Console.ReadKey();
                continue;
            }

            Console.Clear();
            Console.WriteLine("WALLET DETAILS");
            Console.WriteLine($"{selectedWallet.Name}");
            Console.WriteLine($"Currency: {selectedWallet.Currency}");
            Console.WriteLine($"Total: {selectedWallet.TotalAmount}");
            Console.WriteLine();

            var transactions = transactionManager
                .GetTransactionsByWalletId(walletId);

            Console.WriteLine("TRANSACTIONS\n");

            foreach (var transaction in transactions)
            {
                // Console.WriteLine($"{transaction.Id}");
                Console.WriteLine($"{transaction.Date:g}");
                Console.WriteLine($"{transaction.Amount} ({transaction.Category})");
                Console.WriteLine(transaction.Description);
                Console.WriteLine(transaction.IsExpense ? "Expense" : "Income");
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
        }
    }
}