using System.Collections.ObjectModel;
using System.Windows.Input;
using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;

namespace ExpensesManager.MyMauiApp.ViewModels;

public class MainViewModel
{
    private readonly IWalletService _walletService;

    public ObservableCollection<WalletListDto> Wallets { get; }
    public ICommand SelectWalletCommand { get; }

    public MainViewModel(IWalletService walletService)
    {
        _walletService = walletService;

        Wallets = new ObservableCollection<WalletListDto>(
            _walletService.GetAll()
        );

        SelectWalletCommand = new Command<WalletListDto>(async (wallet) =>
        {
            if (wallet is null) return;
            await Shell.Current.GoToAsync($"WalletDetailsPage?walletId={wallet.Id}");
        });
    }
}