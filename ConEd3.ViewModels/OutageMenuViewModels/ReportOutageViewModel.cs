using CommunityToolkit.Mvvm.ComponentModel;
using ConEd3.Services;
using ConEd5.Models;

namespace ConEd3.ViewModels.OutageMenuViewModels;

public partial class ReportOutageViewModel : BaseViewModel {
    private readonly OutageDataService _dataService;

    public string CustomerZipCode => _dataService.CustomerZipCode;

    [ObservableProperty]
    public partial OutageIncident CustomerLocalIncident { get; set; }

    // Strict constructor injection
    public ReportOutageViewModel(OutageDataService dataService) {
        _dataService = dataService;
        CustomerLocalIncident = _dataService.GetOrCreateLocalIncident();

        // The Observer logic stays here, bound to the local ViewModel scope
        CustomerLocalIncident.PropertyChanged += (s, e) => {
            if (e.PropertyName == nameof(OutageIncident.HasUserVoted)) {
                if (CustomerLocalIncident.HasUserVoted && !_dataService.ActiveIncidents.Contains(CustomerLocalIncident)) {
                    _dataService.ActiveIncidents.Insert(0, CustomerLocalIncident);
                }
                else if (!CustomerLocalIncident.HasUserVoted && CustomerLocalIncident.VoteCount <= 0) {
                    _dataService.ActiveIncidents.Remove(CustomerLocalIncident);
                }
            }
        };
    }
}