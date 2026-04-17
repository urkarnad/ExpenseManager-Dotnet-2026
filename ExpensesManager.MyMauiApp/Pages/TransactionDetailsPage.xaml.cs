using ExpensesManager.MyMauiApp.ViewModels;

namespace ExpensesManager.MyMauiApp.Pages;

public partial class TransactionDetailsPage : ContentPage
{
    private readonly TransactionDetailsViewModel _vm;

    public TransactionDetailsPage(TransactionDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(100);
        await _vm.LoadAsync();
    }
}