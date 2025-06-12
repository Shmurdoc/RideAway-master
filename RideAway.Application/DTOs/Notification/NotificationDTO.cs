namespace RideAway.Application.DTOs.Notification
{
    /// <summary>
    /// DTO for in-app notifications.
    /// </summary>
    public class NotificationDTO
    {
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
}
