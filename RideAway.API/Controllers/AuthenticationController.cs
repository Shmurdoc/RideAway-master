using Microsoft.AspNetCore.Mvc;
using RideAway.Application.DTOs.Authentication;
using RideAway.Infrastructure.Authentication;
using RideAway.Application.IRepositories;
using RideAway.Application.IServices.IAuthentication;
using RideAway.Domain.Entities;
using RideAway.Domain.Entities.Enum;

namespace RideAway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly OAuthService _oauthService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationController(OAuthService oauthService, IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
        {
            _oauthService = oauthService;
            _unitOfWork = unitOfWork;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        /// <summary>
        /// Login with Google using IdToken.
        /// </summary>
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.IdToken))
            {
                return BadRequest("IdToken is required.");
            }
            var (isValid, email, name) = await _oauthService.ValidateGoogleIdTokenAsync(dto.IdToken);
            if (!isValid || string.IsNullOrEmpty(email))
            {
                return Unauthorized("Invalid Google token.");
            }

            // User management: create or update user in DB
            var user = await _unitOfWork.UserRepository.GetAllAsync(u => u.Email == email);
            var appUser = user.FirstOrDefault();
            if (appUser == null)
            {
                appUser = new User
                {
                    Name = name,
                    Email = email,
                    Role = UserRole.Rider // Default role, can be changed
                };
                await _unitOfWork.UserRepository.AddAsync(appUser);
                await _unitOfWork.SaveChangesAsync();
            }
            // Generate JWT
            var token = _jwtTokenGenerator.GenerateToken(appUser);
            return Ok(new { Token = token, Email = email, Name = name, Message = "Google login successful." });
        }
    }
}
