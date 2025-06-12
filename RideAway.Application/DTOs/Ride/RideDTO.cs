namespace RideAway.Application.DTOs.Ride
{
    /// <summary>
    /// DTO for creating a ride request.
    /// </summary>
    public class CreateRideRequestDTO
    {
        public Guid RiderId { get; set; }
        public string PickupLocation { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public decimal EstimatedFare { get; set; }
        public RideAway.Domain.Entities.Enum.RideCategory RideCategory { get; set; }
    }

    /// <summary>
    /// DTO for ride details.
    /// </summary>
    public class RideDTO : CreateRideRequestDTO
    {
        public Guid RideId { get; set; }
        public RideAway.Domain.Value_Object.RideStatus Status { get; set; }
    }
}
