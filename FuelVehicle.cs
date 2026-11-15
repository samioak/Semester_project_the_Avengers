public class FuelVehicle : MotorVehicle
{
    public double FuelConsumptionPer100Km { get; set; }
    public double FuelPricePerLiter { get; set; }
    public double Co2GramsPerLiter { get; set; }

    public FuelVehicle() 
        : base("Fuel Vehicle", 50.0)
    {
        FuelConsumptionPer100Km = 8.0;
        FuelPricePerLiter = 1.50;
        Co2GramsPerLiter = 2300.0;
    }

    public override double CalculateCost(double distanceKm)
    {
        return (FuelConsumptionPer100Km / 100) * distanceKm * FuelPricePerLiter;
    }

    public override double CalculateEmissions(double distanceKm)
    {
        return (FuelConsumptionPer100Km / 100) * distanceKm * Co2GramsPerLiter;
    }

    public override string GetAssumptions()
    {
        return $"{Name}: Assumes an average speed of {AvgSpeed} km/h. Fuel consumption is {FuelConsumptionPer100Km} L/100km, fuel price is {FuelPricePerLiter} per liter, and CO2 emissions are {Co2GramsPerLiter} g/L.";
    }
}
