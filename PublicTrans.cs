public class PublicTransport : TransportMode
{
    private const double EstimatedCo2GramsPerKm = 0.1;
    private const double EstimatedKmPerZone = 10.0;
    private const int MinimumFareZones = 2;
    private const int MaximumFareZones = 26;

    private static readonly double[] AdultSingleTicketPriceByZone =
    {
        0, 0, 13, 18, 23, 27, 32, 37, 42, 47,
        52, 57, 62, 67, 72, 77, 82, 87, 92, 97,
        102, 107, 112, 117, 122, 127, 132
    };

    public PublicTransport() : base("Public Transport", 40.0)
    {
    }

    public override double CalculateCost(double distanceKm)
    {
        int estimatedZones = Math.Clamp(
            (int)Math.Ceiling(distanceKm / EstimatedKmPerZone) + 1,
            MinimumFareZones,
            MaximumFareZones);
        return AdultSingleTicketPriceByZone[estimatedZones];
    }

    public override double CalculateEmissions(double distanceKm)
    {
        return EstimatedCo2GramsPerKm * distanceKm;
    }

    public override string GetAssumptions()
    {
        return $"{Name}: Assumes an average speed of {AvgSpeed} km/h. The adult single-ticket fare uses Sydtrafik's fare table for Sønderborg, estimating 2 zones minimum plus 1 zone per 10 km. CO2 emissions are estimated at {EstimatedCo2GramsPerKm} g per kilometer.";
    }
}
