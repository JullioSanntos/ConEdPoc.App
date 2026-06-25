using Microsoft.Maui.Controls;

namespace ConEd.Views.Controls.AttachedProperties;

public static class RegionManager {
    private static readonly Dictionary<Type, Type> _viewRegistry = [];

    public static void Register<TViewModel, TView>() where TView : View {
        _viewRegistry[typeof(TViewModel)] = typeof(TView);
    }

    public static readonly BindableProperty ViewModelProperty =
        BindableProperty.CreateAttached(
            "ViewModel",
            typeof(object),
            typeof(RegionManager),
            null,
            propertyChanged: OnViewModelChanged);

    // Added nullable annotations (?) to match the underlying BindableProperty signature
    public static object? GetViewModel(BindableObject view) => view.GetValue(ViewModelProperty);
    public static void SetViewModel(BindableObject view, object? value) => view.SetValue(ViewModelProperty, value);

    // Added nullable annotations to the event parameters
    private static void OnViewModelChanged(BindableObject bindable, object? oldValue, object? newValue) {
        if (bindable is ContentView container && newValue != null) {
            var viewModelType = newValue.GetType();

            if (_viewRegistry.TryGetValue(viewModelType, out Type? viewType) && viewType != null) {
                // Pattern matching safely casts and checks for null simultaneously
                if (Activator.CreateInstance(viewType) is View view) {
                    view.BindingContext = newValue;
                    container.Content = view;
                }
                else {
                    System.Diagnostics.Debug.WriteLine($"[RegionManager] ERROR: Failed to instantiate {viewType.Name}");
                }
            }
        }
    }
}