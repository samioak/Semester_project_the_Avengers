public class PublicTrans : TransportMode
{
    public double TicketPrice {get; set;}
    public double Co2GramsPerKm {get; set;}
    public override double CalculateCost(double distanceKm)
    {
     return // to be determined how we calculate bus prices with respect to travel distance//
    }
    public override double CalculateEmissions(double distanceKm) 
    {
        return Co2GramsPerKm * distanceKm;
    }  public override string GetAssumptions() 
    { 
        return  //which assumptions? what for?//

    }
}

