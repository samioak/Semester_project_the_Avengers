
public abstract class TransportMode
{
    public string Name { get; set; }
    public double AvgSpeed { get; set; }

    public virtual double CalculateTime(double distanceKm)
    {
        return distanceKm / AvgSpeed;
    }  

    public abstract double CalculateCost(double distanceKm);
    public abstract double CalculateEmissions(double distanceKm);
    public abstract double GetAssumption();


}


