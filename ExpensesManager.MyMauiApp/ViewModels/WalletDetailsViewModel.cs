using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;

namespace ExpensesManager.MyMauiApp.ViewModels;

[QueryProperty(nameof(WalletId), "walletId")]
public class WalletDetailsViewModel : INotifyPropertyChanged
{
    private readonly IWalletService _walletService;

    private WalletDetailsDto _wallet;
    public WalletDetailsDto Wallet
    {
        get => _wallet;
        private set { _wallet = value; OnPropertyChanged(); }
    }

    public ObservableCollection<TransactionListDto> Transactions { get; } = new();

    private string _walletId;
    public string WalletId
    {
        get => _walletId;
        set { _walletId = value; Load(Guid.Parse(value)); }
    }

    public ICommand SelectTransactionCommand { get; }

    public WalletDetailsViewModel(IWalletService walletService)
    {
        _walletService = walletService;

        SelectTransactionCommand = new Command<TransactionListDto>(async (transaction) =>
        {
            if (transaction is null) return;
            await Shell.Current.GoToAsync($"TransactionDetailsPage?transactionId={transaction.Id}");
        });
    }

    private void Load(Guid walletId)
    {
        Wallet = _walletService.GetById(walletId);
        Transactions.Clear();
        foreach (var t in Wallet.Transactions)
            Transactions.Add(t);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}