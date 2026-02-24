namespace LRUCache.UI.Services;

public interface IDialogService
{
    string? OpenFileDialog(string filter);
    void ShowErrorMessage(string errMessage);
    void ShowMessage(string message);
    void ShowWarningMessage(string warnMessage);
}
