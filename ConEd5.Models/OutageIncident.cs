using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Devices.Sensors;

namespace ConEd5.Models;

public partial class OutageIncident : ObservableObject {
    public required int IncidentId { get; init; }
    public required Location Coordinates { get; init; }

    // Adding 'required' guarantees these will never be null, 
    // satisfying the compiler warnings instantly.
    public required string ZipCodes { get; init; }
    public required string ImpactedStreets { get; init; }
    public required string EstimatedRestoration { get; init; }

    public bool IsConfirmed { get; init; }

    [ObservableProperty]
    public partial int VoteCount { get; set; }

    [ObservableProperty]
    public partial bool HasUserVoted { get; set; }

    partial void OnHasUserVotedChanged(bool value) {
        if (value) VoteCount++;
        else VoteCount--;
    }
}