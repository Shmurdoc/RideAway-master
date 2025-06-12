namespace RideAway.Application.DTOs.Authentication
{
    /// <summary>
    /// DTO for Google login authentication.
    /// </summary>
    public class GoogleLoginDTO
    {
        public string IdToken { get; set; } = string.Empty;
    }
}
