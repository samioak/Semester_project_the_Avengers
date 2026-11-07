public class ComparisonEngine {
    public string TransportName { get; set; }
    public double Cost { get; set; }
    public double EmissionsEmmisionGrams { get; set; }
    public double TimeInMinutes { get; set; }
       

    public List<ComparisonResult> Compare(List<TransportMode> transportModes, double distanceKm)
    {
        var results = new List<ComparisonResult>();

        foreach (var mode in transportModes)
        {
            var result = new ComparisonResult
            {
                TransportName = mode.GetType().Name,
                Cost = mode.CalculateCost(distanceKm),
                Emissions = mode.CalculateEmissions(distanceKm),
                TimeInMinutes = mode.CalculateTime(distanceKm)
            };

            results.Add(result);
        }

        return results;
    }
    
    public ComparisonResult GetReccommendation(List<ComparisonResult> results, string criteria)
    {
        switch (criteria)
        {
            case "Cost":
                return results.OrderBy(r => r.Cost).FirstOrDefault();
            case "Emissions":
                return results.OrderBy(r => r.Emissions).FirstOrDefault();
            case "Time":
                return results.OrderBy(r => r.TimeInMinutes).FirstOrDefault();
        }
    }
}