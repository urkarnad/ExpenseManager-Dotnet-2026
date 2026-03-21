namespace ExpensesManager.MyMauiApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("WalletDetailsPage", typeof(Pages.WalletDetailsPage));
        Routing.RegisterRoute("TransactionDetailsPage", typeof(Pages.TransactionDetailsPage));
    }
}