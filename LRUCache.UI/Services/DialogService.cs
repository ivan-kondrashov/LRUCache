using System.Windows;
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

    public void ShowMessage(string message)
    {
        MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public void ShowErrorMessage(string errMessage)
    {
        MessageBox.Show(errMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    public void ShowWarningMessage(string warnMessage)
    {
        MessageBox.Show(warnMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}
