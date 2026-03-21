using ExpensesManager.MyMauiApp.ViewModels;

namespace ExpensesManager.MyMauiApp.Pages;

public partial class TransactionDetailsPage : ContentPage
{
    public TransactionDetailsPage(TransactionDetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}