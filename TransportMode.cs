
public abstract class TransportMode
{
    public string Name { get; protected set; }
    public double AvgSpeed { get; protected set; }

    protected TransportMode(string name, double avgSpeed)
    {
        Name = name;
        AvgSpeed = avgSpeed;
    }

    public virtual double CalculateTime(double distanceKm)
    {
        return distanceKm / AvgSpeed * 60;
    }  

    public abstract double CalculateCost(double distanceKm);
    public abstract double CalculateEmissions(double distanceKm);
    public abstract string GetAssumptions();


}


