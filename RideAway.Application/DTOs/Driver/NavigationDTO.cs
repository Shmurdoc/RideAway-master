namespace RideAway.Application.DTOs.Driver
{
    /// <summary>
    /// DTO for driver navigation and routing.
    /// </summary>
    public class NavigationDTO
    {
        public Guid DriverId { get; set; }
        public string CurrentLocation { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string[] RouteSteps { get; set; } = Array.Empty<string>();
        public double EstimatedTimeMinutes { get; set; }
        public double EstimatedDistanceKm { get; set; }
        public bool HasRealTimeTraffic { get; set; }
    }
}
