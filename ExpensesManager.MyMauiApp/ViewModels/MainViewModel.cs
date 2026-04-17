using System.Collections.ObjectModel;
using System.Windows.Input;
using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;
using ExpensesManager.Storage.Enums;

namespace ExpensesManager.MyMauiApp.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly IWalletService _walletService;

    private List<WalletListDto> _allWallets = new();
    public ObservableCollection<WalletListDto> Wallets { get; } = new();

    private string _searchText = "";
    public string SearchText
    {
        get => _searchText;
        set { _searchText = value; OnPropertyChanged(); ApplyFilter(); }
    }

    private string _selectedSort = "Name ↑";
    public string SelectedSort
    {
        get => _selectedSort;
        set { _selectedSort = value; OnPropertyChanged(); ApplyFilter(); }
    }
    public List<string> SortOptions { get; } = new() { "Name ↑", "Name ↓" };

    private string _newWalletName = "";
    public string NewWalletName
    {
        get => _newWalletName;
        set { _newWalletName = value; OnPropertyChanged(); }
    }

    private Currency _newWalletCurrency = Currency.UAH;
    public Currency NewWalletCurrency
    {
        get => _newWalletCurrency;
        set { _newWalletCurrency = value; OnPropertyChanged(); }
    }

    public List<Currency> Currencies { get; } = Enum.GetValues<Currency>().ToList();

    public ICommand LoadCommand { get; }
    public ICommand SelectWalletCommand { get; }
    public ICommand AddWalletCommand { get; }
    public ICommand DeleteWalletCommand { get; }

    public MainViewModel(IWalletService walletService)
    {
        _walletService = walletService;

        LoadCommand = new Command(async () => await LoadAsync());

        SelectWalletCommand = new Command<WalletListDto>(async wallet =>
        {
            if (wallet is null || IsBusy) return;
            await Shell.Current.GoToAsync($"WalletDetailsPage?walletId={wallet.Id}");
        });

        AddWalletCommand = new Command(async () => await AddWalletAsync());

        DeleteWalletCommand = new Command<WalletListDto>(async wallet =>
        {
            if (wallet is null || IsBusy) return;
            bool confirm = await Shell.Current.DisplayAlert(
                "Delete Wallet",
                $"Delete \"{wallet.Name}\" and all its transactions?",
                "Delete", "Cancel");
            if (!confirm) return;
            await RunBusyAsync(async () =>
            {
                await _walletService.DeleteAsync(wallet.Id);
                _allWallets.Remove(wallet);
                ApplyFilter();
            });
        });
    }

    public async Task LoadAsync()
    {
        await RunBusyAsync(async () =>
        {
            var wallets = await _walletService.GetAllAsync();
            _allWallets = wallets.ToList();
            ApplyFilter();
        });
    }

    private void ApplyFilter()
    {
        var filtered = _allWallets
            .Where(w => string.IsNullOrWhiteSpace(SearchText)
                        || w.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

        filtered = SelectedSort switch
        {
            "Name ↓" => filtered.OrderByDescending(w => w.Name),
            _ => filtered.OrderBy(w => w.Name)
        };

        Wallets.Clear();
        foreach (var w in filtered)
            Wallets.Add(w);
    }

    private async Task AddWalletAsync()
    {
        if (string.IsNullOrWhiteSpace(NewWalletName)) return;
        await RunBusyAsync(async () =>
        {
            var dto = await _walletService.AddAsync(NewWalletName.Trim(), NewWalletCurrency);
            _allWallets.Add(dto);
            NewWalletName = "";
            ApplyFilter();
        });
    }
}