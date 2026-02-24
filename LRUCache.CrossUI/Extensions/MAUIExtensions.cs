namespace LRUCache.CrossUI.Extensions;

public static class MAUIExtensions
{
    public static void AddView<TView, TViewModel>(this IServiceCollection services)
            where TView : ContentPage, new()
            where TViewModel : notnull
    {
        services.AddSingleton<TView>(serviceProvider => new TView()
        {
            BindingContext = serviceProvider.GetRequiredService<TViewModel>()
        });
    }
}
