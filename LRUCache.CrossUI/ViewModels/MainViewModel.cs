using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LRUCache.CrossUI.Models;
using LRUCache.CrossUI.Services;

namespace LRUCache.CrossUI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ICsvService _csvService;
    private readonly IDialogService _dialogService;

    [ObservableProperty]
    private ISeries[] _timeSeries = [];

    [ObservableProperty]
    private ISeries[] _memorySeries = [];

    [ObservableProperty]
    private Axis[] _xAxes = [];

    public MainViewModel(ICsvService csvService, IDialogService dialogService)
    {
        _csvService = csvService;
        _dialogService = dialogService;
    }

    [RelayCommand]
    private async Task SelectFile()
    {
        var filePath = await _dialogService.OpenFileDialogAsync("CSV files (*.csv)|*.csv|All files (*.*)|*.*");
        if (filePath != null)
        {
            try
            {
                var results = await _csvService.LoadBenchmarkDataAsync(filePath);
                if (results.Any())
                {
                    UpdateTimeChart(results);
                    UpdateMemoryChart(results);
                }
            }
            catch (IOException)
            {
                await _dialogService.ShowErrorMessageAsync($"File {filePath} is already open!");
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorMessageAsync(ex.Message);
            }
        }
    }

    private void UpdateTimeChart(List<BenchmarkInfo> results)
    {
        var uniqueItemsCounts = results.Select(r => r.ItemsCount).Distinct().OrderBy(c => c).ToList();
        var methods = results.Select(r => r.Method).Distinct().ToList();

        var series = new List<ISeries>();
        foreach (var method in methods)
        {
            var methodResults = results.Where(r => r.Method == method).OrderBy(r => r.ItemsCount).ToList();
            series.Add(new ColumnSeries<double>
            {
                Name = method,
                Values = uniqueItemsCounts.Select(count => 
                    methodResults.FirstOrDefault(r => r.ItemsCount == count)?.TimeNs ?? 0).ToArray()
            });
        }

        TimeSeries = series.ToArray();

        XAxes = new Axis[]
        {
            new Axis
            {
                Labels = uniqueItemsCounts.Select(c => c.ToString()).ToArray(),
                Name = "Items Count"
            }
        };
    }

    private void UpdateMemoryChart(List<BenchmarkInfo> results)
    {
        var uniqueItemsCounts = results.Select(r => r.ItemsCount).Distinct().OrderBy(c => c).ToList();
        var methods = results.Select(r => r.Method).Distinct().ToList();

        var series = new List<ISeries>();
        foreach (var method in methods)
        {
            var methodResults = results.Where(r => r.Method == method).OrderBy(r => r.ItemsCount).ToList();
            series.Add(new ColumnSeries<double>
            {
                Name = method,
                Values = uniqueItemsCounts.Select(count => 
                    methodResults.FirstOrDefault(r => r.ItemsCount == count)?.MemoryBytes ?? 0).ToArray()
            });
        }

        MemorySeries = series.ToArray();
    }
}
