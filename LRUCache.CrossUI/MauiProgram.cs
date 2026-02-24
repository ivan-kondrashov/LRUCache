using LiveChartsCore.SkiaSharpView.Maui;
using LRUCache.CrossUI.Extensions;
using LRUCache.CrossUI.Services;
using LRUCache.CrossUI.ViewModels;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace LRUCache.CrossUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSkiaSharp()
            .UseLiveCharts()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<ICsvService, CsvService>();
        builder.Services.AddSingleton<IDialogService, DialogService>();

        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<AppShell>();
        builder.Services.AddView<MainPage, MainViewModel>();

        return builder.Build();
    }
}
