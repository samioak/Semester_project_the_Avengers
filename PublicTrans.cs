public class PublicTrans : TransportMode
{
    public double TicketPrice {get; set;}
    public double Co2GramsPerKm {get; set;}
    public override double CalculateCost(double distanceKm)
    {
     return // the bus prices here are lwk stupid af, will fill later
    }
    public override double CalculateEmissions(double distanceKm) 
    {
        return Co2GramsPerKm * distanceKm;
    }  public override string GetAssumptions() 
    { 
        return  //i dont get this, will ask jakub//

    }
}

