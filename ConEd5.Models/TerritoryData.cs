
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

    public static List<OutageIncident> GetActiveOutages() {
        return
        [ new OutageIncident(
              IncidentId: 2,
              Coordinates: new Location(40.84, -73.87),
              ZipCodes: "10460, 10462",
              ImpactedStreets: "Bronx Park East, White Plains Rd, Morris Park Ave",
              EstimatedRestoration: "Today at 6:45 PM"),

          // Manhattan Area

          new OutageIncident(
              IncidentId: 24,
              Coordinates: new Location(40.75, -73.98),
              ZipCodes: "10018, 10001",
              ImpactedStreets: "W 34th St, W 35th St, 7th Ave to 9th Ave",
              EstimatedRestoration: "Assessing Condition"),

          // Brooklyn Area

          new OutageIncident(
              IncidentId: 3,
              Coordinates: new Location(40.65, -73.95),
              ZipCodes: "11226, 11203",
              ImpactedStreets: "Flatbush Ave, Church Ave, Linden Blvd",
              EstimatedRestoration: "Tomorrow at 10:00 AM") ];
    }
}