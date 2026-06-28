using Microsoft.Maui.Devices.Sensors;

namespace ConEd5.Models;

public record OutageIncident(
    int IncidentId,
    Location Coordinates,
    string ZipCodes,
    string ImpactedStreets,
    string EstimatedRestoration
);