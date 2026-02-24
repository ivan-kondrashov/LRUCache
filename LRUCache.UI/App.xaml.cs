using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LRUCache.UI.Services;
using LRUCache.UI.ViewModels;
using LRUCache.UI.Views;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace LRUCache.UI;

public partial class App : Application
{
    public static IHost AppHost { get; private set; } = null!;

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddScoped<ICsvService, CsvService>();
                services.AddScoped<IDialogService, DialogService>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost.StartAsync();

        LiveCharts.Configure(config =>
            config.UseDefaults());

        var startForm = AppHost.Services.GetRequiredService<MainWindow>();
        startForm.DataContext = AppHost.Services.GetRequiredService<MainViewModel>();
        startForm.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost.StopAsync();
        AppHost.Dispose();

        base.OnExit(e);
    }
}
