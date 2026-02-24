namespace LRUCache.CrossUI.Services;

public interface IDialogService
{
    Task<string?> OpenFileDialogAsync(string filter);
    Task ShowErrorMessageAsync(string errMessage);
    Task ShowMessageAsync(string message);
    Task ShowWarningMessageAsync(string warnMessage);
}
