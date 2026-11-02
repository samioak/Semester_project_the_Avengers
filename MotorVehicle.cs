
public class MotorVehicle : TransportMode {
    public double FuelConsumptionPer100Km {get; set;}
    public double FuelPricePerLiter {get; set;}
    public double Co2GramsPerLiter {get; set;}
    
public override double CalculateCost(double distanceKm) { 
    return FuelConsumptionPer100Km * FuelPricePerLiter * (distanceKm/100.0);
} // fuel consumption per 100 km * fuel price per liter * distance / 100 (since the fuel consumptoin is per 100km)  

public override double CalculateEmissions(double distanceKm) {
    return FuelConsumptionPer100Km * Co2GramsPerLiter * (distanceKm/100.0);
} // fuel consumption per 100 km * the amount of co2 released from the burnt fuel in grams * distance / 100 (since the fuel consumption is per 100km)  

public override GetAssumption() { //string or double? UML diagram states string, but inheriting type double from transport mode
    return $""; //what kind of assumptions? fuel consumption, fuel price per l, emissions? or the output of CalculateCost() and CalculateEmissions()
}
}