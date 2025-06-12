namespace RideAway.Application.DTOs.Authentication
{
    /// <summary>
    /// DTO for email/phone login authentication.
    /// </summary>
    public class LoginDTO
    {
        public string EmailOrPhone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
