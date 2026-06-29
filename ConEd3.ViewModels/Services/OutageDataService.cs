using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ConEd5.Models;

namespace ConEd3.Services;

public partial class OutageDataService : ObservableObject {
    private static readonly string[] MockZipCodes = { "10460", "10018", "11226", "07201", "10001" };

    public string CustomerZipCode { get; }

    // The shared public grid data
    public ObservableCollection<OutageIncident> ActiveIncidents { get; }

    public OutageDataService() {
        CustomerZipCode = MockZipCodes[new Random().Next(MockZipCodes.Length)];
        ActiveIncidents = new ObservableCollection<OutageIncident>(TerritoryData.GetActiveOutages());
    }

    // A helper method for the Report form to use
    public OutageIncident GetOrCreateLocalIncident() {
        var existing = ActiveIncidents.FirstOrDefault(i => i.ZipCodes.Contains(CustomerZipCode));
        if (existing != null) return existing;

        return new OutageIncident {
            IncidentId = new Random().Next(1000, 9999),
            Coordinates = new Location(40.66, -74.21), // Standard default anchor
            ZipCodes = CustomerZipCode,
            ImpactedStreets = "Pending verification...",
            EstimatedRestoration = "Assessing condition...",
            IsConfirmed = false,
            VoteCount = 0
        };
    }
}