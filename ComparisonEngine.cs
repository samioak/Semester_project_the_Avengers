public class ComparisonEngine {
    public class ComparisonResult
    {
        public string TransportName { get; set; }
        public double Cost { get; set; }
        public double Emissions { get; set; }
        public double TimeInMinutes { get; set; }
    }   

    public List<ComparisonResult> CompareTransportModes(List<TransportMode> transportModes, double distanceKm)
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
    
    public ComparisonResult GetBestOption(List<ComparisonResult> results, string criteria)
    {
        switch (criteria)
        {
            case "cost":
                return results.OrderBy(r => r.Cost).FirstOrDefault();
            case "emissions":
                return results.OrderBy(r => r.Emissions).FirstOrDefault();
            case "time":
                return results.OrderBy(r => r.TimeInMinutes).FirstOrDefault();
        }
    }
}