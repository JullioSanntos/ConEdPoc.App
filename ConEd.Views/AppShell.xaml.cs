using System.ComponentModel;
using ConEd3.ViewModels;

namespace ConEd.Views;

public partial class AppShell : Shell {
    private bool _isNavigatingFromViewModel;

    public AppShell() {
        InitializeComponent();
        MainViewModel.Instance.PropertyChanged += OnGlobalStateChanged;
    }

    // ==========================================
    // 1. VM -> UI (Uses the Tab Control's Route)
    // ==========================================
    private async void OnGlobalStateChanged(object? sender, PropertyChangedEventArgs e) {
        if (e?.PropertyName == nameof(MainViewModel.ActiveGlobalTab)) {
            _isNavigatingFromViewModel = true;

            // First, resolve the strongly-typed Enum to the physical XAML element reference
            Tab targetTab = MainViewModel.Instance.ActiveGlobalTab switch {
                AppGlobalTab.PayMyBill => PayMyBillTab,
                AppGlobalTab.Usage => UsageTab,
                AppGlobalTab.Manage => ManageTab,
                AppGlobalTab.Outage => OutageTab,
                AppGlobalTab.ContactUs => ContactUsTab,
                _ => PayMyBillTab
            };

            // Dynamically construct the route using the control's own property.
            // No hardcoded string literals. If XAML shifts, this auto-updates.
            string absoluteRoute = $"//{targetTab.Route}";

            await GoToAsync(absoluteRoute);

            _isNavigatingFromViewModel = false;
        }
    }

    // ==========================================
    // UI -> VM (Object Comparison, No Strings)
    // ==========================================
    protected override void OnNavigated(ShellNavigatedEventArgs args) {
        base.OnNavigated(args);

        if (_isNavigatingFromViewModel) return;

        // Step down into the hierarchy: Shell -> TabBar -> Tab
        var activeTab = this.CurrentItem?.CurrentItem;

        // Compare the physical Tab objects directly
        if (activeTab == PayMyBillTab)
            MainViewModel.Instance.ActiveGlobalTab = AppGlobalTab.PayMyBill;
        else if (activeTab == UsageTab)
            MainViewModel.Instance.ActiveGlobalTab = AppGlobalTab.Usage;
        else if (activeTab == ManageTab)
            MainViewModel.Instance.ActiveGlobalTab = AppGlobalTab.Manage;
        else if (activeTab == OutageTab)
            MainViewModel.Instance.ActiveGlobalTab = AppGlobalTab.Outage;
        else if (activeTab == ContactUsTab)
            MainViewModel.Instance.ActiveGlobalTab = AppGlobalTab.ContactUs;
    }
}