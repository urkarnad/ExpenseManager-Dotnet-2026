using ExpensesManager.MyMauiApp.ViewModels;
using ExpensesManager.MyMauiApp.Pages;
using ExpensesManager.Services.Interfaces;
using ExpensesManager.Services.Services;
using ExpensesManager.Services.Storage;
using ExpensesManager.Storage.Interfaces;
using ExpensesManager.Storage.Repositories;
using Microsoft.Extensions.Logging;

namespace ExpensesManager.MyMauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Storage
        builder.Services.AddSingleton<FakeStorage>();
        builder.Services.AddSingleton<IWalletRepository, WalletRepository>();
        builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();

        // Services
        builder.Services.AddSingleton<IWalletService, WalletService>();
        builder.Services.AddSingleton<ITransactionService, TransactionService>();

        // ViewModels
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<WalletDetailsViewModel>();
        builder.Services.AddTransient<TransactionDetailsViewModel>();

        // Pages
        builder.Services.AddTransient<WalletListPage>();
        builder.Services.AddTransient<WalletDetailsPage>();
        builder.Services.AddTransient<TransactionDetailsPage>();

        return builder.Build();
    }
}