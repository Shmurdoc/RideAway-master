namespace RideAway.Application.DTOs.Ride
{
    /// <summary>
    /// DTO for ride feedback and reviews.
    /// </summary>
    public class FeedbackDTO
    {
        public Guid RideId { get; set; }
        public Guid ReviewerId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
