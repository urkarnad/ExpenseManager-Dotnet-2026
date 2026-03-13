using ExpensesManager.Domain.Models;

namespace ExpensesManager.MyMauiApp.Pages;

public partial class WalletDetailsPage : ContentPage
{
    private readonly Wallet _wallet;

    public WalletDetailsPage(Wallet wallet)
    {
        InitializeComponent();

        _wallet = wallet;

        WalletName.Text = wallet.Name;
        WalletCurrency.Text = $"Currency: {wallet.Currency}";
        WalletBalance.Text = $"Balance: {wallet.TotalAmount}";

        TransactionsList.ItemsSource = wallet.Transactions;
    }

    private async void TransactionSelected(object sender, SelectionChangedEventArgs e)
    {
        var transaction = e.CurrentSelection.FirstOrDefault() as Transaction;

        if (transaction == null)
            return;

        await Navigation.PushAsync(new TransactionDetailsPage(transaction));
    }
}