namespace RideAway.Application.DTOs.Support
{
    /// <summary>
    /// DTO for customer support chat/helpdesk.
    /// </summary>
    public class SupportChatDTO
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
        public bool IsFromSupport { get; set; }
    }
}
