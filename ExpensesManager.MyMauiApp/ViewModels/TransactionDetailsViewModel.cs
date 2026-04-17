using System.Windows.Input;
using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;
using ExpensesManager.Storage.Enums;

namespace ExpensesManager.MyMauiApp.ViewModels;

[QueryProperty(nameof(TransactionId), "transactionId")]
public class TransactionDetailsViewModel : BaseViewModel
{
    private readonly ITransactionService _transactionService;

    private TransactionDetailsDto? _transaction;
    public TransactionDetailsDto? Transaction
    {
        get => _transaction;
        private set { _transaction = value; OnPropertyChanged(); }
    }

    private string _transactionId = "";
    public string TransactionId
    {
        get => _transactionId;
        set { _transactionId = value; }
    }

    private string _editAmount = "";
    public string EditAmount
    {
        get => _editAmount;
        set { _editAmount = value; OnPropertyChanged(); }
    }

    private string _editDescription = "";
    public string EditDescription
    {
        get => _editDescription;
        set { _editDescription = value; OnPropertyChanged(); }
    }

    private TransactionCategory _editCategory;
    public TransactionCategory EditCategory
    {
        get => _editCategory;
        set { _editCategory = value; OnPropertyChanged(); }
    }

    public List<TransactionCategory> Categories { get; } = Enum.GetValues<TransactionCategory>().ToList();

    public ICommand LoadCommand { get; }
    public ICommand SaveCommand { get; }

    public TransactionDetailsViewModel(ITransactionService transactionService)
    {
        _transactionService = transactionService;

        LoadCommand = new Command(async () => await LoadAsync());

        SaveCommand = new Command(async () =>
        {
            if (Transaction is null) return;
            if (!decimal.TryParse(EditAmount.Replace(',', '.'),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out decimal amount))
            {
                await Shell.Current.DisplayAlert("Error", "Invalid amount", "OK");
                return;
            }

            await RunBusyAsync(async () =>
            {
                await _transactionService.UpdateAsync(Transaction.Id, amount, EditCategory, EditDescription.Trim());
                await LoadAsync();
                await Shell.Current.DisplayAlert("Saved", "Transaction updated.", "OK");
            });
        });
    }

    public async Task LoadAsync()
    {
        if (string.IsNullOrEmpty(TransactionId)) return;
        await RunBusyAsync(async () =>
        {
            Transaction = await _transactionService.GetByIdAsync(Guid.Parse(TransactionId));
            EditAmount = Transaction.Amount.ToString("F2");
            EditDescription = Transaction.Description;
            EditCategory = Transaction.Category;
        });
    }
}