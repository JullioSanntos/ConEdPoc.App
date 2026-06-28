
namespace ConEd5.Models;

public static class TerritoryData {
    public static List<GeoCoordinate> GetConEdBoundary() {
        return
        [ new GeoCoordinate(41.30, -73.98),
          new GeoCoordinate(41.20, -73.75),
          new GeoCoordinate(40.95, -73.65),
          new GeoCoordinate(40.80, -73.75),
          new GeoCoordinate(40.60, -73.75),
          new GeoCoordinate(40.50, -74.25),
          new GeoCoordinate(40.65, -74.24),
          new GeoCoordinate(40.75, -74.05),
          new GeoCoordinate(40.95, -73.94) ];
    }
}