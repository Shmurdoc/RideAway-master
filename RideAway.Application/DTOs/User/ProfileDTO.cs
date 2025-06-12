namespace RideAway.Application.DTOs.User
{
    /// <summary>
    /// DTO for user profile management.
    /// </summary>
    public class ProfileDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public RideAway.Domain.Entities.Enum.UserRole Role { get; set; }
    }
}
