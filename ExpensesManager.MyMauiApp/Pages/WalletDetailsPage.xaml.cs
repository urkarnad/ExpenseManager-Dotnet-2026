using ExpensesManager.MyMauiApp.ViewModels;

namespace ExpensesManager.MyMauiApp.Pages;

public partial class WalletDetailsPage : ContentPage
{
    private readonly WalletDetailsViewModel _vm;

    public WalletDetailsPage(WalletDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadAsync();
    }
}