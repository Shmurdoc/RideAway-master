namespace RideAway.Application.DTOs.Notification
{
    /// <summary>
    /// DTO for driver arrival notification.
    /// </summary>
    public class DriverArrivalNotificationDTO
    {
        public Guid RideId { get; set; }
        public Guid DriverId { get; set; }
        public Guid RiderId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
