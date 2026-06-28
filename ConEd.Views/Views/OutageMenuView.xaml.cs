using Microsoft.Maui.Maps;

namespace ConEd.Views.Views;

public partial class OutageMenuView : ContentPage
{
	public OutageMenuView()
	{
		InitializeComponent();

        // Target the center of Con Edison territory (New York City)
        Location mapCenter = new Location(40.7128, -74.0060);

        // The two 0.5 values represent the Latitude and Longitude zoom radius.
        // This will display a wide view covering the 5 boroughs and surrounding areas.
        MapSpan mapSpan = new MapSpan(mapCenter, 0.5, 0.5);

        // Command the map to move the camera
        OutageMap.MoveToRegion(mapSpan);
    }
}