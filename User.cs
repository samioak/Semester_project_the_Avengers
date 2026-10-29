public class User
{
    private List<TransportMode> availableTransportModes;
    private ComparisonEngine engine;

    private string criteria= "Time"; 
    public User()
    {
        availableTransportModes = new List<TransportMode>
        {
            new MotorVehicle(),
            new PublicTransport(),
            new Cycling(),
            new Walking()
        };
        engine = new ComparisonEngine();
    }
    public void Start()
    {
        double distance = Get_Valid_Distance();
        var results = engine.Compare(distance, availableTransportModes);
        Displayresults(results);
        var reccommendation = engine.GetRecommendation(results,criteria);
        Console.WriteLine($"Recommended Transport Mode based on {criteria}: {reccommendation.TransportName}");
        DisplayAssumpitions();
    }
    private double Get_Valid_Distance()
    {
        try
        {
            Console.WriteLine("Enter the distance in kilometers: ");
            double distance = Convert.ToDouble(Console.ReadLine());
            if (distance < 0)
            {
                Console.WriteLine("Distance cannot be negative. Please enter a valid distance.");
                return Get_Valid_Distance();
            }
            return distance;
        }
        catch(FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return Get_Valid_Distance();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            return Get_Valid_Distance();
        }
    }

    private void Displayresults(List<ComparisonResult> results)
    {
        Console.WriteLine("Comparison Results:");
        foreach (var result in results)
        {
            Console.WriteLine($"Transport Mode: {result.TransportName}");
            Console.WriteLine($"Time: {result.TimeInMinutes} minutes");
            Console.WriteLine($"Cost: {result.Cost} dkk");
            Console.WriteLine($"Emissions: {result.Co2EmissionsGrams} g CO2");
            Console.WriteLine("---------------------------");
        }
    }

    private void DisplayAssumpitions()
    {
        Console.WriteLine("Assumptions");
    }

     static void Main(string[] args)
    {
        User user = new User();
        double distance = user.Get_Valid_Distance();
        Console.WriteLine($"You entered a valid distance of {distance} km.");
    }



}

