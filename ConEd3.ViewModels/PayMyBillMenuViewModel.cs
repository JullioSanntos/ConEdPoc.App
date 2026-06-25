using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConEd3.ViewModels.PayMyBillViewModels;
// ReSharper disable InconsistentNaming

namespace ConEd3.ViewModels;

public partial class PayMyBillMenuViewModel : ObservableObject {
    // Properties exposing the routing constants for XAML data-binding
    public const string CurrentBillRoute = nameof(CurrentBillViewModel);
    public const string BillHistoryRoute = nameof(BillHistoryViewModel);
    public const string PayBillRoute = nameof(PayBillViewModel);

    [ObservableProperty]
    public partial object ActiveViewModel { get; set; }

    public PayMyBillMenuViewModel() {
        ActiveViewModel = new CurrentBillViewModel();
    }

    // Resolves the new state based on the strongly-typed route name
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