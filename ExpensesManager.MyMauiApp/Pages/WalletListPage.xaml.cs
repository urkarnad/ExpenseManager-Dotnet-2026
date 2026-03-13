using ExpensesManager.Services.Services;
using ExpensesManager.Domain.Models;

namespace ExpensesManager.MyMauiApp.Pages;

public partial class WalletListPage : ContentPage
{
	private readonly WalletService _walletService;
	public WalletListPage(WalletService walletService)
    {
        InitializeComponent();

        _walletService = walletService;

        WalletList.ItemsSource = _walletService.GetAllWallets();
    }

    private async void WalletSelected(object sender, SelectionChangedEventArgs e)
    {
        var wallet = e.CurrentSelection.FirstOrDefault() as Wallet;

        if (wallet == null)
            return;

        await Shell.Current.Navigation.PushAsync(new WalletDetailsPage(wallet));
    }
}