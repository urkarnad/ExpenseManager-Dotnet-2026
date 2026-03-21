namespace ExpensesManager.MyMauiApp;

public static class ServiceHelper
{
    public static IServiceProvider Services =>
        IPlatformApplication.Current!.Services;

    public static T GetService<T>() where T : notnull =>
        Services.GetRequiredService<T>();
}