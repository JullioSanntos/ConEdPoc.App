using ConEd5.Models;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace ConEd.Views.Views.OutageMenuViews;

public partial class OutageMapView : ContentView {
    public OutageMapView() {
        InitializeComponent();

        Dispatcher.DispatchAsync(async () => {
            await Task.Delay(100);
            Location mapCenter = new Location(40.92, -73.95);
            MapSpan mapSpan = new MapSpan(mapCenter, 0.75, 0.75);
            OutageMap.MoveToRegion(mapSpan);
        });

        DrawServiceBoundary();
        PlotOutagePins();
    }

    private void DrawServiceBoundary() {
        Polygon territoryPolygon = new Polygon {
            StrokeColor = Color.FromArgb("#0072C6"),
            StrokeWidth = 6,
            FillColor = Colors.Transparent
        };

        List<GeoCoordinate> boundaryPoints = TerritoryData.GetConEdBoundary();

        foreach (var point in boundaryPoints) {
            Location uiLocation = new Location(point.Latitude, point.Longitude);
            territoryPolygon.Geopath.Add(uiLocation);
        }

        OutageMap.MapElements.Add(territoryPolygon);
    }

    private void PlotOutagePins() {
        // Assuming you are grabbing the data from your new shared service or ViewModel
        var incidents = TerritoryData.GetActiveOutages(); // Or your ViewModel source

        foreach (var incident in incidents) {
            Pin outagePin = new Pin {
                Label = $"Incident #{incident.IncidentId}",
                Address = incident.ZipCodes,
                Type = PinType.Generic,
                Location = incident.Coordinates
            };

            // NEW: Use MarkerClicked instead of InfoWindowClicked
            outagePin.MarkerClicked += (s, e) => {
                // This magic line prevents the native tooltip from ever showing
                e.HideInfoWindow = true;

                // Show your custom overlay instantly
                ShowOutageDetails(incident);
            };

            OutageMap.Pins.Add(outagePin);
        }
    }

    private void ShowOutageDetails(OutageIncident incident) {
        PopupTitle.Text = $"Incident #{incident.IncidentId}";
        PopupZips.Text = incident.ZipCodes;
        PopupStreets.Text = incident.ImpactedStreets;
        PopupETA.Text = incident.EstimatedRestoration;
        OutageDetailsOverlay.IsVisible = true;
    }

    private void ClosePopup_Clicked(object sender, EventArgs e) {
        OutageDetailsOverlay.IsVisible = false;
    }
}