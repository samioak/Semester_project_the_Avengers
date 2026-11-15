public class Walking : TransportMode
{
    public Walking() : base("Walking", 5.0) 
    {
    }
    public override double CalculateTime(double distanceKm)
    {
        return distanceKm / AvgSpeed * 60;
    }

    public override double CalculateCost(double distanceKm) => 0;
    public override double CalculateEmissions(double distanceKm) => 0;

    public override string GetAssumptions() 
    { 
        return $"{Name}: Assumes an average speed of {AvgSpeed} km/h. Costs nothing and produces 0g of CO2 emissions."; 
    }
}   