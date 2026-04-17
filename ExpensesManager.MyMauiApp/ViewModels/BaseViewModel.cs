using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExpensesManager.MyMauiApp.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    private bool _isBusy;
    public bool IsBusy
    {
        get => _isBusy;
        set { _isBusy = value; OnPropertyChanged(); OnPropertyChanged(nameof(IsNotBusy)); }
    }
    public bool IsNotBusy => !_isBusy;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    protected async Task RunBusyAsync(Func<Task> action)
    {
        IsBusy = true;
        try { await action(); }
        finally { IsBusy = false; }
    }
}