using LRUCache.CrossUI.Services;

namespace LRUCache.CrossUI.Services;

public class DialogService : IDialogService
{
    public async Task<string?> OpenFileDialogAsync(string filter)
    {
        var customFileType = new FilePickerFileType(
            new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.iOS, new[] { "public.comma-separated-values-text" } }, 
                { DevicePlatform.Android, new[] { "text/comma-separated-values" } },
                { DevicePlatform.WinUI, new[] { ".csv" } },
                { DevicePlatform.Tizen, new[] { "*/*" } },
                { DevicePlatform.macOS, new[] { "csv" } },
            });

        var options = new PickOptions
        {
            PickerTitle = "Select Benchmark CSV",
            FileTypes = customFileType,
        };

        var result = await FilePicker.Default.PickAsync(options);
        return result?.FullPath;
    }

    public async Task ShowErrorMessageAsync(string errMessage)
    {
        if (Application.Current?.MainPage != null)
        {
            await Application.Current.MainPage.DisplayAlertAsync("Error", errMessage, "OK");
        }
    }

    public async Task ShowMessageAsync(string message)
    {
        if (Application.Current?.MainPage != null)
        {
            await Application.Current.MainPage.DisplayAlertAsync("Information", message, "OK");
        }
    }

    public async Task ShowWarningMessageAsync(string warnMessage)
    {
        if (Application.Current?.MainPage != null)
        {
            await Application.Current.MainPage.DisplayAlertAsync("Warning", warnMessage, "OK");
        }
    }
}
