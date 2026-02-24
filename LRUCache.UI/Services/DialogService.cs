using Microsoft.Win32;

namespace LRUCache.UI.Services;

public class DialogService : IDialogService
{
    public string? OpenFileDialog(string filter)
    {
        var dialog = new OpenFileDialog
        {
            Filter = filter
        };

        return dialog.ShowDialog() == true ? dialog.FileName : null;
    }
}
