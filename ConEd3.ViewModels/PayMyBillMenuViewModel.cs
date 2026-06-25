using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConEd3.ViewModels.PayMyBillViewModels;

namespace ConEd3.ViewModels;

public partial class PayMyBillMenuViewModel : ObservableObject {
    // Compile-time constants for routing
    public const string CurrentBillRoute = nameof(CurrentBillViewModel);
    public const string BillHistoryRoute = nameof(BillHistoryViewModel);
    public const string PayBillRoute = nameof(PayBillViewModel);

    // Forces UI to re-evaluate the boolean properties below when state changes
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsCurrentBillActive))]
    [NotifyPropertyChangedFor(nameof(IsBillHistoryActive))]
    [NotifyPropertyChangedFor(nameof(IsPayBillActive))]
    public partial object ActiveViewModel { get; set; }

    // Explicit computed properties for the TabItem visual states
    public bool IsCurrentBillActive => ActiveViewModel is CurrentBillViewModel;
    public bool IsBillHistoryActive => ActiveViewModel is BillHistoryViewModel;
    public bool IsPayBillActive => ActiveViewModel is PayBillViewModel;

    public PayMyBillMenuViewModel() {
        ActiveViewModel = new CurrentBillViewModel();
    }

    [RelayCommand]
    private void SwitchTab(string route) {
        ActiveViewModel = route switch {
            CurrentBillRoute => new CurrentBillViewModel(),
            BillHistoryRoute => new BillHistoryViewModel(),
            PayBillRoute => new PayBillViewModel(),
            _ => ActiveViewModel
        };
    }
}