namespace RideAway.Application.DTOs.Driver
{
    /// <summary>
    /// DTO for driver ride request and dispatch.
    /// </summary>
    public class DispatchRequestDTO
    {
        public Guid RequestId { get; set; }
        public Guid DriverId { get; set; }
        public Guid RideId { get; set; }
        public string PickupLocation { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime RequestedAt { get; set; }
        public bool IsAccepted { get; set; }
    }
}
