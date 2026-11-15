public class ElectricVehicle : MotorVehicle
{
    public double EnergyConsumptionPer100Km { get; set; }
    public double ElectricityPricePerKWh { get; set; }
    public double Co2GramsPerKWh { get; set; }

    public ElectricVehicle() 
        : base("Electric Vehicle", 60.0)
    {
        EnergyConsumptionPer100Km = 15.0;
        ElectricityPricePerKWh = 0.30;
        Co2GramsPerKWh = 200.0;
    }

    public override double CalculateTime(double distanceKm)
    {
        return distanceKm / AvgSpeed * 60;
    }

    public override double CalculateCost(double distanceKm)
    {
        double energyUsed = (EnergyConsumptionPer100Km / 100) * distanceKm;
        return energyUsed * ElectricityPricePerKWh;
    }

    public override double CalculateEmissions(double distanceKm)
    {
        double energyUsed = (EnergyConsumptionPer100Km / 100) * distanceKm;
        return energyUsed * Co2GramsPerKWh;
    }

    public override string GetAssumptions()
    {
        return $"{Name}: Assumes an average speed of {AvgSpeed} km/h. Costs are based on electricity consumption and CO2 emissions are based on electricity generation.";
    }
}
