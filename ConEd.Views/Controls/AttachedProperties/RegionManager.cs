using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConEd.Views.Controls.AttachedProperties;

public static class RegionManager {
    // =========================================================
    // Register your ViewModel-View pairs here for explicit routing. This is the preferred method.
    // =========================================================
    private static readonly Dictionary<Type, Type> _viewRegistry = new();

    // Keeping your exact naming convention!
    public static void Register<TViewModel, TView>() where TView : View {
        _viewRegistry[typeof(TViewModel)] = typeof(TView);
    }

    // The attached property that will be used to bind the ViewModel to the ContentView
    public static readonly BindableProperty ViewModelProperty = BindableProperty.CreateAttached(
        propertyName: "ViewModel",
        returnType: typeof(object),
        declaringType: typeof(RegionManager),
        defaultValue: null,
        propertyChanged: OnViewModelChanged);

    public static object GetViewModel(BindableObject bindable) => bindable.GetValue(ViewModelProperty);
    public static void SetViewModel(BindableObject bindable, object value) => bindable.SetValue(ViewModelProperty, value);

    // When ViewModel changes, we need to resolve the corresponding View and set it as the Content of the ContentView
    private static void OnViewModelChanged(BindableObject bindable, object oldValue, object newValue) {
        if (bindable is not ContentView contentView) return;

        if (newValue == null) {
            contentView.Content = null;
            return;
        }

        Type viewModelType = newValue.GetType();
        Type? viewType = null;

        // Check Your Centralized Manifest First. Configuration over convention ---
        if (_viewRegistry.TryGetValue(viewModelType, out Type? registeredType)) {
            viewType = registeredType;
        }
        else {
            // --- Fallback to Magic String Inference. Name convention fallback 
            string targetViewFullName = viewModelType.FullName!
                .Replace("ViewModel", "View")
                .Replace("ConEd3.", "ConEd.");

            viewType = typeof(RegionManager).Assembly.GetType(targetViewFullName);

            if (viewType == null) {
                string fallbackName = targetViewFullName.Replace("ConEd.Views.", "ConEd.Views.Views.");
                viewType = typeof(RegionManager).Assembly.GetType(fallbackName);
            }
        }

        // Visual feedback for developers if the view type could not be resolved
        if (viewType == null) {
            contentView.Content = new VerticalStackLayout {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label { Text = "⚠ Routing Error", TextColor = Colors.Red, FontSize = 24, FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center },
                    new Label { Text = $"Not registered and inference failed for:\n{viewModelType.Name}", TextColor = Colors.Red, HorizontalTextAlignment = TextAlignment.Center }
                }
            };
            return;
        }

        // Instantiate the view and set its BindingContext to the new ViewModel
        try {
            if (Activator.CreateInstance(viewType) is View viewInstance) {
                viewInstance.BindingContext = newValue;
                contentView.Content = viewInstance;
            }
        }
        catch (Exception ex) {
            Debug.WriteLine($"[RegionManager] CRITICAL ERROR instantiating {viewType.Name}: {ex.Message}");
            contentView.Content = new Label { Text = $"Error instantiating {viewType.Name}", TextColor = Colors.Red, HorizontalOptions = LayoutOptions.Center };
        }
    }
}