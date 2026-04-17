using ExpensesManager.MyMauiApp.Pages;
using ExpensesManager.MyMauiApp.ViewModels;
using ExpensesManager.Services.Interfaces;
using ExpensesManager.Services.Services;
using ExpensesManager.Storage.Database;
using ExpensesManager.Storage.Interfaces;
using ExpensesManager.Storage.Repositories;
using ExpensesManager.Storage.Storage;
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

        var dataDir = FileSystem.AppDataDirectory;

        // Storage layer
        builder.Services.AddSingleton(new JsonStorage(dataDir));
        builder.Services.AddSingleton<IWalletRepository, WalletRepository>();
        builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();
        builder.Services.AddSingleton<DatabaseSeeder>();

        // Service layer
        builder.Services.AddSingleton<IWalletService, WalletService>();
        builder.Services.AddSingleton<ITransactionService, TransactionService>();

        // ViewModels
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<WalletDetailsViewModel>();
        builder.Services.AddTransient<TransactionDetailsViewModel>();

        // Pages
        builder.Services.AddSingleton<WalletListPage>();
        builder.Services.AddTransient<WalletDetailsPage>();
        builder.Services.AddTransient<TransactionDetailsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}