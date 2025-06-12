namespace RideAway.Application.DTOs.Driver
{
    /// <summary>
    /// DTO for driver ratings and performance.
    /// </summary>
    public class DriverRatingDTO
    {
        public Guid DriverId { get; set; }
        public double AverageRating { get; set; }
        public int TotalRides { get; set; }
        public int Compliments { get; set; }
        public int Complaints { get; set; }
    }
}
