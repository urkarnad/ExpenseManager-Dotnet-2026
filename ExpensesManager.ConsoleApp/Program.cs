using ExpensesManager.Presentation.Managers;
using ExpensesManager.Services.Services;

namespace ExpensesManager.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        var walletService = new WalletService();
        var transactionService = new TransactionService();
        
        var walletManager = new WalletManager(walletService);
        var transactionManager = new TransactionManager(transactionService);
        
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Welcome to ExpensesManager!\n");
            Console.WriteLine("WALLET LIST");
            walletManager.ShowAllWallets();

            Console.WriteLine();
            Console.WriteLine("Enter Wallet ID to see the details or type 0 to exit");
            
            var input = Console.ReadLine();
            if (input == "0")
            {
                exit = true;
                continue;
            }

            if (!Guid.TryParse(input, out var walletId))
            {
                Console.WriteLine("Invalid Wallet ID");
                Console.ReadKey();
                continue;
            }
            
            Console.Clear();
            walletManager.ShowWalletDetails(walletId);
            Console.WriteLine();
            
            Console.WriteLine("Press any key to see transactions");
            Console.ReadKey();
            Console.Clear();
            
            transactionManager.ShowTransactionDetails(walletId);
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
