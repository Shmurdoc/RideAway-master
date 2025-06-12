namespace RideAway.Application.DTOs.Ride
{
    /// <summary>
    /// DTO for real-time ride tracking.
    /// </summary>
    public class RideTrackingDTO
    {
        public Guid RideId { get; set; }
        public string CurrentLocation { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public double ProgressPercent { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
