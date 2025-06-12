namespace RideAway.Application.DTOs.Ride
{
    /// <summary>
    /// DTO for displaying available rides.
    /// </summary>
    public class AvailableRideDTO
    {
        public Guid RideId { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public string VehicleInfo { get; set; } = string.Empty;
        public string PickupLocation { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public decimal EstimatedFare { get; set; }
        public RideAway.Domain.Entities.Enum.RideCategory RideCategory { get; set; }
        public double DriverRating { get; set; }
    }
}
