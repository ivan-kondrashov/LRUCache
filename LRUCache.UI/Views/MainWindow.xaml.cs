using System.Windows;
using System.Windows.Data;
using LiveChartsCore.SkiaSharpView.WPF;

namespace LRUCache.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SetupCharts();
    }

    private void SetupCharts()
    {
        var timeChart = new CartesianChart();
        timeChart.SetBinding(CartesianChart.SeriesProperty, new Binding("TimeSeries"));
        timeChart.SetBinding(CartesianChart.XAxesProperty, new Binding("XAxes"));
        TimeChartContainer.Content = timeChart;

        var memoryChart = new CartesianChart();
        memoryChart.SetBinding(CartesianChart.SeriesProperty, new Binding("MemorySeries"));
        memoryChart.SetBinding(CartesianChart.XAxesProperty, new Binding("XAxes"));
        MemoryChartContainer.Content = memoryChart;
    }
}
