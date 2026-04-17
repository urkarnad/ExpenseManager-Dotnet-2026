using System.Collections.ObjectModel;
using System.Windows.Input;
using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;
using ExpensesManager.Storage.Enums;

namespace ExpensesManager.MyMauiApp.ViewModels;

[QueryProperty(nameof(WalletId), "walletId")]
public class WalletDetailsViewModel : BaseViewModel
{
    private readonly IWalletService _walletService;
    private readonly ITransactionService _transactionService;

    private List<TransactionListDto> _allTransactions = new();

    private WalletDetailsDto? _wallet;
    public WalletDetailsDto? Wallet
    {
        get => _wallet;
        private set { _wallet = value; OnPropertyChanged(); }
    }

    public ObservableCollection<TransactionListDto> Transactions { get; } = new();

    private string _walletId = "";
    public string WalletId
    {
        get => _walletId;
        set { _walletId = value; }
    }

    private string _searchText = "";
    public string SearchText
    {
        get => _searchText;
        set { _searchText = value; OnPropertyChanged(); ApplyFilter(); }
    }

    private string _selectedSort = "Date ↓";
    public string SelectedSort
    {
        get => _selectedSort;
        set { _selectedSort = value; OnPropertyChanged(); ApplyFilter(); }
    }
    public List<string> SortOptions { get; } = new() { "Date ↓", "Date ↑", "Amount ↓", "Amount ↑" };

    private string _editName = "";
    public string EditName
    {
        get => _editName;
        set { _editName = value; OnPropertyChanged(); }
    }

    private Currency _editCurrency;
    public Currency EditCurrency
    {
        get => _editCurrency;
        set { _editCurrency = value; OnPropertyChanged(); }
    }

    public List<Currency> Currencies { get; } = Enum.GetValues<Currency>().ToList();

    private string _newAmount = "";
    public string NewAmount
    {
        get => _newAmount;
        set { _newAmount = value; OnPropertyChanged(); }
    }

    private string _newDescription = "";
    public string NewDescription
    {
        get => _newDescription;
        set { _newDescription = value; OnPropertyChanged(); }
    }

    private TransactionCategory _newCategory = TransactionCategory.Other;
    public TransactionCategory NewCategory
    {
        get => _newCategory;
        set { _newCategory = value; OnPropertyChanged(); }
    }

    public List<TransactionCategory> Categories { get; } = Enum.GetValues<TransactionCategory>().ToList();

    public ICommand LoadCommand { get; }
    public ICommand SelectTransactionCommand { get; }
    public ICommand SaveWalletCommand { get; }
    public ICommand AddTransactionCommand { get; }
    public ICommand DeleteTransactionCommand { get; }

    public WalletDetailsViewModel(IWalletService walletService, ITransactionService transactionService)
    {
        _walletService = walletService;
        _transactionService = transactionService;

        LoadCommand = new Command(async () => await LoadAsync());

        SelectTransactionCommand = new Command<TransactionListDto>(async t =>
        {
            if (t is null || IsBusy) return;
            await Shell.Current.GoToAsync($"TransactionDetailsPage?transactionId={t.Id}");
        });

        SaveWalletCommand = new Command(async () =>
        {
            if (Wallet is null || string.IsNullOrWhiteSpace(EditName)) return;
            await RunBusyAsync(async () =>
            {
                await _walletService.UpdateAsync(Wallet.Id, EditName.Trim(), EditCurrency);
                await LoadAsync();
            });
        });

        AddTransactionCommand = new Command(async () => await AddTransactionAsync());

        DeleteTransactionCommand = new Command<TransactionListDto>(async t =>
        {
            if (t is null || IsBusy) return;
            bool confirm = await Shell.Current.DisplayAlert("Delete", "Delete this transaction?", "Delete", "Cancel");
            if (!confirm) return;
            await RunBusyAsync(async () =>
            {
                await _transactionService.DeleteAsync(t.Id);
                _allTransactions.Remove(t);
                ApplyFilter();
                await RefreshBalanceAsync();
            });
        });
    }

    public async Task LoadAsync()
    {
        if (string.IsNullOrEmpty(WalletId)) return;
        await RunBusyAsync(async () =>
        {
            Wallet = await _walletService.GetByIdAsync(Guid.Parse(WalletId));
            EditName = Wallet.Name;
            EditCurrency = Wallet.Currency;
            _allTransactions = Wallet.Transactions.ToList();
            ApplyFilter();
        });
    }

    private async Task RefreshBalanceAsync()
    {
        Wallet = await _walletService.GetByIdAsync(Guid.Parse(WalletId));
    }

    private void ApplyFilter()
    {
        var filtered = _allTransactions.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(SearchText))
            filtered = filtered.Where(t =>
                t.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                t.Category.ToString().Contains(SearchText, StringComparison.OrdinalIgnoreCase));

        filtered = SelectedSort switch
        {
            "Date ↑" => filtered.OrderBy(t => t.Date),
            "Amount ↓" => filtered.OrderByDescending(t => t.Amount),
            "Amount ↑" => filtered.OrderBy(t => t.Amount),
            _ => filtered.OrderByDescending(t => t.Date)
        };

        Transactions.Clear();
        foreach (var t in filtered)
            Transactions.Add(t);
    }

    private async Task AddTransactionAsync()
    {
        if (!decimal.TryParse(NewAmount.Replace(',', '.'),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal amount))
        {
            await Shell.Current.DisplayAlert("Error", "Invalid amount", "OK");
            return;
        }

        if (Wallet is null) return;

        await RunBusyAsync(async () =>
        {
            var dto = await _transactionService.AddAsync(Wallet.Id, amount, NewCategory, NewDescription.Trim());
            _allTransactions.Add(dto);
            NewAmount = "";
            NewDescription = "";
            NewCategory = TransactionCategory.Other;
            ApplyFilter();
            await RefreshBalanceAsync();
        });
    }
}