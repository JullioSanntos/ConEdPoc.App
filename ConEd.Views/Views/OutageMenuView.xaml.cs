using ConEd5.Models;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace ConEd.Views.Views;

public partial class OutageMenuView : ContentPage {
    public OutageMenuView() {
        InitializeComponent();

        // Let the page render instantly, then move the camera a split second later
        Dispatcher.DispatchAsync(async () => {
            await Task.Delay(100); // Give the UI thread a breath
            Location mapCenter = new Location(40.92, -73.95);
            MapSpan mapSpan = new MapSpan(mapCenter, 0.75, 0.75);
            OutageMap.MoveToRegion(mapSpan);
        });

        // Render the custom service boundary polygon layer
        DrawServiceBoundary();
    }

    /// <summary>
    /// Fetches pure C# domain coordinates, maps them to MAUI UI objects, 
    /// and renders the transparent boundary polygon on top of the map layer.
    /// </summary>
    private void DrawServiceBoundary() {
        //尊Instantiate the MAUI Map Polygon control with transparent fill
        Polygon territoryPolygon = new Polygon {
            StrokeColor = Color.FromArgb("#0072C6"), // ConEd Corporate Blue
            StrokeWidth = 6,
            FillColor = Colors.Transparent           // Completely transparent interior
        };

        // 1. Fetch decoupled, framework-agnostic coordinate data from the Model layer
        List<GeoCoordinate> boundaryPoints = TerritoryData.GetConEdBoundary();

        // 2. Map-translate Domain models into specific MAUI UI objects on the fly
        foreach (var point in boundaryPoints) {
            Location uiLocation = new Location(point.Latitude, point.Longitude);
            territoryPolygon.Geopath.Add(uiLocation);
        }

        // 3. Inject the constructed polygon layer directly into the native map surface
        OutageMap.MapElements.Add(territoryPolygon);
    }
}