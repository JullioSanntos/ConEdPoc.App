using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConEd3.Services;
using ConEd3.ViewModels.OutageMenuViewModels;

namespace ConEd3.ViewModels;

public partial class OutageMenuViewModel : BaseViewModel {
    // The single shared state instance created when the parent boots up
    private readonly OutageDataService _sharedDataService = new OutageDataService();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsOutageMapVisible))]
    [NotifyPropertyChangedFor(nameof(IsCheckStatusVisible))]
    [NotifyPropertyChangedFor(nameof(IsReportOutageVisible))]
    public partial string ActiveInternalTab { get; set; } = "OUTAGE MAP";

    public bool IsOutageMapVisible => ActiveInternalTab == "OUTAGE MAP";
    public bool IsCheckStatusVisible => ActiveInternalTab == "CHECK STATUS";
    public bool IsReportOutageVisible => ActiveInternalTab == "REPORT OUTAGE";

    // =========================================================
    // LAZY INSTANTIATION OF SUB-VIEWMODELS
    // =========================================================

    private ReportOutageViewModel? _reportOutageVm;
    public ReportOutageViewModel ReportOutageViewModel =>
        _reportOutageVm ??= new ReportOutageViewModel(_sharedDataService);

    private CheckStatusViewModel? _checkStatusVm;
    public CheckStatusViewModel CheckStatusViewModel =>
        _checkStatusVm ??= new CheckStatusViewModel(_sharedDataService);

    // If OutageMapViewModel eventually needs the data, you inject it exactly the same way here
    private OutageMapViewModel? _outageMapVm;
    public OutageMapViewModel OutageMapViewModel =>
        _outageMapVm ??= new OutageMapViewModel();

    [RelayCommand]
    private void SwitchTab(string tabName) {
        ActiveInternalTab = tabName;
    }
}