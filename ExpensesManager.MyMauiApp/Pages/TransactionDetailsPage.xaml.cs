using ExpensesManager.Domain.Models;

namespace ExpensesManager.MyMauiApp.Pages;

public partial class TransactionDetailsPage : ContentPage
{
    public TransactionDetailsPage(Transaction transaction)
    {
        InitializeComponent();

        AmountLabel.Text = $"Amount: {transaction.Amount}";
        CategoryLabel.Text = $"Category: {transaction.Category}";
        DescriptionLabel.Text = $"Description: {transaction.Description}";
        DateLabel.Text = $"Date: {transaction.Date}";
    }
}