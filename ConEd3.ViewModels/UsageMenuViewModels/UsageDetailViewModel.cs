using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ConEd5.Models;

namespace ConEd3.ViewModels.UsageMenuViewModels;

public partial class UsageDetailViewModel : BaseViewModel {
    [ObservableProperty]
    public partial string MacroDateRange { get; set; } = "May 2019– May 2020";

    [ObservableProperty]
    public partial ObservableCollection<string> AvailableServices { get; set; } = ["Electricity 1", "Gas 1"];

    [ObservableProperty]
    public partial string SelectedService { get; set; } = "Electricity 1";

    [ObservableProperty]
    public partial string MicroDateRange { get; set; } = "Apr 7, 2020 – May 7, 2020";

    [ObservableProperty]
    public partial decimal PeriodCost { get; set; } = 45.38m;

    [ObservableProperty]
    public partial int AverageTemperature { get; set; } = 55;

    [ObservableProperty]
    public partial ObservableCollection<UsageDataPoint> ChartData { get; set; } = [];

    public UsageDetailViewModel() {
        SelectedService = AvailableServices[0];

        // The chart height is now 240px. The max value is $120.
        // Multiplier is exactly 2.0. (e.g., $45 * 2 = 90px height)
        ChartData =
        [
            new UsageDataPoint("May", 45, 90),
            new UsageDataPoint("Jun", 55, 110),
            new UsageDataPoint("Jul", 105, 210),
            new UsageDataPoint("Aug", 110, 220),
            new UsageDataPoint("Sep", 85, 170),
            new UsageDataPoint("Oct", 75, 150),
            new UsageDataPoint("Nov", 60, 120),

            new UsageDataPoint("Dec", 45, 90, true),
            new UsageDataPoint("Jan", 40, 80, true),
            new UsageDataPoint("Feb", 35, 70, true),

            new UsageDataPoint("Mar", 30, 60),
            new UsageDataPoint("Apr", 45, 90),
            new UsageDataPoint("May", 45, 90)
        ];
    }
}