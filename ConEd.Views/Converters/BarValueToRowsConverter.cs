using System.Globalization;

namespace ConEd.Views.Converters;

public class BarValueToRowsConverter : IValueConverter {
    private const double ChartHeight = 240; // must match the Path's anchor point in the view
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        var filled = Math.Max(System.Convert.ToDouble(value), 0.01);
        var empty = Math.Max(ChartHeight - filled, 0);
        var rows = new RowDefinitionCollection();
        rows.Add(new RowDefinition(new GridLength(empty, GridUnitType.Star)));
        rows.Add(new RowDefinition(new GridLength(filled, GridUnitType.Star)));
        return rows;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException();
}