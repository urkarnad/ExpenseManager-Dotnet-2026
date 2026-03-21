using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExpensesManager.Services.DTOs;
using ExpensesManager.Services.Interfaces;

namespace ExpensesManager.MyMauiApp.ViewModels;

[QueryProperty(nameof(TransactionId), "transactionId")]
public class TransactionDetailsViewModel : INotifyPropertyChanged
{
    private readonly ITransactionService _transactionService;

    private TransactionDetailsDto _transaction;
    public TransactionDetailsDto Transaction
    {
        get => _transaction;
        private set { _transaction = value; OnPropertyChanged(); }
    }

    private string _transactionId;
    public string TransactionId
    {
        get => _transactionId;
        set { _transactionId = value; Transaction = _transactionService.GetById(Guid.Parse(value)); }
    }

    public TransactionDetailsViewModel(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}