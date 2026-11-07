public class User
{
    private List<TransportMode> availableTransportModes;
    private ComparisonEngine engine;

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
        List<TransportMode> selected = SelectTransports();
        double distance = Get_Valid_Distance();
        var results = engine.Compare(distance, selected);
        Displayresults(results);

        string criteria = GetCriteria();
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

    private List<TransportMode> SelectTransports()
    {
        Console.WriteLine("Select transport modes to compare (comma-separated):");
        for (int i = 0; i < availableTransportModes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableTransportModes[i].Name}");
        }

        string input = Console.ReadLine();
        var selectedIndices = input.Split(',').Select(s => int.Parse(s.Trim()) - 1).ToList();
        var selectedTransports = new List<TransportMode>();

        foreach (var index in selectedIndices)
        {
            if (index >= 0 && index < availableTransportModes.Count)
            {
                selectedTransports.Add(availableTransportModes[index]);
            }
            else
            {
                Console.WriteLine($"Invalid selection: {index + 1}. Please select valid transport modes.");
                return SelectTransports();
            }
        }

        if (selectedTransports.Count == 0)
        {
            Console.WriteLine("No valid transport modes selected. Please select at least one valid transport mode.");
            return SelectTransports();
        }
        else if (selectedTransports.Count < 2)
        {
            Console.WriteLine("You must select at least 2 transport modes. Please select again.");
            return SelectTransports();
        }
        
        return selectedTransports;
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

    public string GetCriteria()
    {
        Console.WriteLine("Select criteria for recommendation (Cost, Emissions, Time):");
        try{
            string criteria = Console.ReadLine();
            if(criteria != "Cost" && criteria != "Emissions" && criteria != "Time")
            {
                Console.WriteLine("Invalid criteria. Please select either 'Cost', 'Emissions', or 'Time'.");
                return GetCriteria();
            }
            return criteria;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            return GetCriteria();
        }
        catch(FormatException)
        {
            Console.WriteLine("Invalid input. Please select either 'Cost', 'Emissions', or 'Time'.");
            return GetCriteria();
        }

    }


    private void DisplayAssumpitions()
    {
        foreach (var transport in SelectTransports())
        {
            Console.WriteLine($"Assumptions for {transport.Name}:");
            Console.WriteLine(transport.GetAssumptions());
            Console.WriteLine("---------------------------");
        }
    }

}

