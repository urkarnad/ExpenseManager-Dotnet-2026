using ExpensesManager.MyMauiApp.ViewModels;

namespace ExpensesManager.MyMauiApp.Pages;

public partial class WalletDetailsPage : ContentPage
{
    public WalletDetailsPage(WalletDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}