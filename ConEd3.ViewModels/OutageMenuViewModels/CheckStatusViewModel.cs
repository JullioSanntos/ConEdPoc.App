using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ConEd3.Services;
using ConEd5.Models;

namespace ConEd3.ViewModels.OutageMenuViewModels;

public partial class CheckStatusViewModel : BaseViewModel {
    private readonly OutageDataService _dataService;

    // Expose the shared list to the UI
    public ObservableCollection<OutageIncident> ActiveIncidents => _dataService.ActiveIncidents;

    public CheckStatusViewModel(OutageDataService dataService) {
        _dataService = dataService;
    }
}