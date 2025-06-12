namespace RideAway.Application.DTOs.Ride
{
    /// <summary>
    /// DTO for fare estimation.
    /// </summary>
    public class FareEstimationDTO
    {
        public string PickupLocation { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public decimal EstimatedFare { get; set; }
        public double EstimatedDistanceKm { get; set; }
        public double EstimatedTimeMinutes { get; set; }
    }
}
