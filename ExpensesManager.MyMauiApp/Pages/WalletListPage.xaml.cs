using ExpensesManager.MyMauiApp.ViewModels;

namespace ExpensesManager.MyMauiApp.Pages;

public partial class WalletListPage : ContentPage
{
    public WalletListPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}