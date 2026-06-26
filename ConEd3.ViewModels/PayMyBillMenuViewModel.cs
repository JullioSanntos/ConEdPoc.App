using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConEd3.ViewModels.PayMyBillViewModels;

namespace ConEd3.ViewModels;

public partial class PayMyBillMenuViewModel : BaseViewModel {
    // ADD THESE BACK: The XAML compiler needs these to resolve the CommandParameters!
    public const string CurrentBillRoute = nameof(CurrentBillRoute);
    public const string BillHistoryRoute = nameof(BillHistoryRoute);
    public const string PayBillRoute = nameof(PayBillRoute);

    public CurrentBillViewModel CurrentBillVm => field ??= new ();

    private PayBillViewModel? _payBillVm;
    public PayBillViewModel PayBillVm => _payBillVm ??= new PayBillViewModel();

    private BillHistoryViewModel? _billHistoryVm;
    public BillHistoryViewModel BillHistoryVm => _billHistoryVm ??= new BillHistoryViewModel();


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsCurrentBillActive), nameof(IsPayBillActive), nameof(IsBillHistoryActive))]
    public partial object ActiveViewModel { get; set; } 
    public bool IsCurrentBillActive => ActiveViewModel == CurrentBillVm;
    public bool IsPayBillActive => ActiveViewModel == PayBillVm;
    public bool IsBillHistoryActive => ActiveViewModel == BillHistoryVm;

    public PayMyBillMenuViewModel() {
        ActiveViewModel = CurrentBillVm!;
    }


    [RelayCommand]
    private void SwitchTab(string route) {
        ActiveViewModel = route switch {
            CurrentBillRoute => CurrentBillVm,
            PayBillRoute => PayBillVm,
            BillHistoryRoute => BillHistoryVm,
            _ => CurrentBillVm
        };
    }
}