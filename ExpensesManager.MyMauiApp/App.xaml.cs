using ExpensesManager.Storage.Database;
using ExpensesManager.Storage.Storage;

namespace ExpensesManager.MyMauiApp;

public partial class App : Application
{
    public App(JsonStorage jsonStorage, DatabaseSeeder seeder)
    {
        InitializeComponent();
        MainPage = new AppShell();

        Task.Run(async () =>
        {
            await seeder.SeedIfEmptyAsync();
        }).GetAwaiter().GetResult();
    }
}