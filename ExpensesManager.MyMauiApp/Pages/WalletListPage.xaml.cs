using ExpensesManager.MyMauiApp.ViewModels;

namespace ExpensesManager.MyMauiApp.Pages;

public partial class WalletListPage : ContentPage
{
    private readonly MainViewModel _vm;

    public WalletListPage(MainViewModel vm)
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