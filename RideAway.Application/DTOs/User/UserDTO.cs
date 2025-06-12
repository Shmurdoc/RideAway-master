namespace RideAway.Application.DTOs.User
{
    /// <summary>
    /// Data Transfer Object for user information.
    /// </summary>
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public RideAway.Domain.Entities.Enum.UserRole Role { get; set; }
    }

    /// <summary>
    /// DTO for creating a new user (registration).
    /// </summary>
    public class CreateUserDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RideAway.Domain.Entities.Enum.UserRole Role { get; set; }
    }

    /// <summary>
    /// DTO for updating driver location.
    /// </summary>
    public class DriverLocationUpdateDTO
    {
        public Guid DriverId { get; set; }
        public string CurrentLocation { get; set; } = string.Empty;
    }
}
