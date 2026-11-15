public class User
{
    private readonly List<string> availableTransportModes;
    private ComparisonEngine engine;

    public User()
    {
        availableTransportModes = new List<string>
        {
            "Motor Vehicle",
            "Public Transport",
            "Cycling",
            "Walking"
        };
        engine = new ComparisonEngine();
    }
    public void Start()
    {
        List<TransportMode> selected = SelectTransports();
        double distance = Get_Valid_Distance();
        List<ComparisonResult> results = engine.Compare(selected, distance);
        Displayresults(results);

        string criteria = GetCriteria();
        ComparisonResult recommendation = engine.GetRecommendation(results, criteria);
        Console.WriteLine($"Recommended Transport Mode based on {criteria}: {recommendation.TransportName}");
        DisplayAssumpitions(selected);
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

    private List<TransportMode> SelectTransports()
    {
        while (true)
        {
            Console.WriteLine("Select at least 2 transport modes to compare (comma-separated):");
            for (int i = 0; i < availableTransportModes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableTransportModes[i]}");
            }

            string[] choices = (Console.ReadLine() ?? string.Empty).Split(',');
            var selectedTransports = new List<TransportMode>();
            var selectedIndices = new HashSet<int>();
            bool isValid = choices.Length >= 2;

            foreach (string choice in choices)
            {
                if (!int.TryParse(choice.Trim(), out int selectedIndex) ||
                    selectedIndex < 1 ||
                    selectedIndex > availableTransportModes.Count ||
                    !selectedIndices.Add(selectedIndex))
                {
                    isValid = false;
                    break;
                }

                TransportMode chosenMode = selectedIndex switch
                {
                    1 => SelectMotorVehicleType(),
                    2 => new PublicTransport(),
                    3 => new Cycling(),
                    4 => new Walking(),
                    _ => throw new InvalidOperationException("Unknown transport mode.")
                };
                selectedTransports.Add(chosenMode);
            }

            if (isValid)
            {
                return selectedTransports;
            }

            Console.WriteLine("Invalid selection. Enter at least 2 different valid numbers separated by commas.");
        }
    }

    private MotorVehicle SelectMotorVehicleType()
    {
        while (true)
        {
            Console.WriteLine("Select motor vehicle power type:");
            Console.WriteLine("1. Electric");
            Console.WriteLine("2. Fuel-powered");

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    return new ElectricVehicle();
                case "2":
                    return new FuelVehicle();
                default:
                    Console.WriteLine("Invalid selection. Please enter 1 or 2.");
                    break;
            }
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
            Console.WriteLine($"Emissions: {result.Emissions} g CO2");
            Console.WriteLine("---------------------------");
        }
    }

    public string GetCriteria()
    {
        while (true)
        {
            Console.WriteLine("Select criteria for recommendation (Cost, Emissions, Time):");
            string? criteria = Console.ReadLine()?.Trim();
            if (criteria == "Cost" || criteria == "Emissions" || criteria == "Time")
            {
                return criteria;
            }

            Console.WriteLine("Invalid criteria. Please select either 'Cost', 'Emissions', or 'Time'.");
        }
    }


    private void DisplayAssumpitions(List<TransportMode> selectedTransports)
    {
      
        foreach (var transport in selectedTransports)
        {
            Console.WriteLine($"Assumptions for {transport.Name}:");
            Console.WriteLine(transport.GetAssumptions());
            Console.WriteLine("---------------------------");
        }
    }

}
