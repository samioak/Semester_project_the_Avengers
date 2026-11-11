public class Walking : TransportMode
{
    public override double CalculateTime(double distanceKm, double AvgSpeed)
    {
        return distanceKm / AvgSpeed;
    }

    public override string GetAssumptions() 
    { 
        return; 
    }
}