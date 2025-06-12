namespace RideAway.Application.DTOs.Ride
{
    /// <summary>
    /// DTO for trip history and feedback.
    /// </summary>
    public class TripHistoryDTO
    {
        public Guid RideId { get; set; }
        public Guid RiderId { get; set; }
        public Guid DriverId { get; set; }
        public string PickupLocation { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime RideDate { get; set; }
        public decimal Fare { get; set; }
        public int? Rating { get; set; }
        public string? Feedback { get; set; }
    }
}
