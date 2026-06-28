using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ConEd3.ViewModels;

public partial class ManageMenuViewModel : BaseViewModel {
    // ==========================================
    // 1. ACCOUNT IDENTITY
    // ==========================================
    [ObservableProperty]
    public partial string MaskedAccountNumber { get; set; } = "••••••••••8936";

    [ObservableProperty]
    public partial string FullAccountNumber { get; set; } = "10029384758936";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayAccountNumber))]
    public partial bool IsAccountVisible { get; set; } = false;

    public string DisplayAccountNumber => IsAccountVisible ? FullAccountNumber : MaskedAccountNumber;


    [ObservableProperty]
    public partial string ServiceAddressLine1 { get; set; } = "123 MAIN STREET, 2RHM";

    [ObservableProperty]
    public partial string ServiceAddressLine2 { get; set; } = "NEW YORK, NY 10001";

    // ==========================================
    // 2. BILLING SUMMARY CARD
    // ==========================================
    [ObservableProperty]
    public partial decimal AmountDue { get; set; } = 198.82m;

    [ObservableProperty]
    public partial string DueDate { get; set; } = "Aug 19, 2018";

    // ==========================================
    // 3. COMMANDS
    // ==========================================
    [RelayCommand]
    private void ToggleAccountVisibility() {
        IsAccountVisible = !IsAccountVisible;
    }

    [RelayCommand]
    private void PayBill() {
        MainViewModel.Instance.PayMyBillMenuViewModel.ActiveViewModel = MainViewModel.Instance.PayMyBillMenuViewModel.PayBillVm;

        // Global active tab (Triggers the Shell to navigate)
        MainViewModel.Instance.ActiveGlobalTab = AppGlobalTab.PayMyBill;
    }

    [RelayCommand]
    private void StopService() { }

    [RelayCommand]
    private void MoveService() { }

    [RelayCommand]
    private void RequestExtension() { }
}