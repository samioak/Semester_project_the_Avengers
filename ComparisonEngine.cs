public class ComparisonEngine {
    public List<ComparisonResult> Compare(List<TransportMode> transportModes, double distanceKm)
    {
        var results = new List<ComparisonResult>();

        foreach (var mode in transportModes)
        {
            var result = new ComparisonResult
            {
                TransportName = mode.Name,
                Cost = mode.CalculateCost(distanceKm),
                Emissions = mode.CalculateEmissions(distanceKm),
                TimeInMinutes = mode.CalculateTime(distanceKm)
            };

            results.Add(result);
        }

        return results;
    }
    
    public ComparisonResult GetRecommendation(List<ComparisonResult> results, string criteria)
    {
        return criteria switch
        {
            "Cost" => results.OrderBy(r => r.Cost).First(),
            "Emissions" => results.OrderBy(r => r.Emissions).First(),
            "Time" => results.OrderBy(r => r.TimeInMinutes).First(),
            _ => throw new ArgumentException("Criteria must be Cost, Emissions, or Time.", nameof(criteria))
        };
    }
}

public class ComparisonResult
{
    public string TransportName { get; set; } = string.Empty;
    public double Cost { get; set; }
    public double Emissions { get; set; }
    public double TimeInMinutes { get; set; }
}
