using Microsoft.AspNetCore.Mvc;
using RideAway.Application.DTOs.User;
using RideAway.Application.IRepositories;
using RideAway.Domain.Entities;
using System.Security.Claims;

namespace RideAway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProfileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get the current user's profile.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            // In production, get userId from JWT claims
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
                return Unauthorized();
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);
            if (user == null)
                return NotFound();
            var profile = new ProfileDTO
            {
                UserId = user.Id,
                Name = user.Name ?? string.Empty,
                Email = user.Email ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                ProfilePictureUrl = null, // Add if available
                Role = user.Role
            };
            return Ok(profile);
        }

        /// <summary>
        /// Update the current user's profile.
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileDTO dto)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(dto.UserId);
            if (user == null)
                return NotFound();
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            // user.ProfilePictureUrl = dto.ProfilePictureUrl; // Add if available
            // Save changes (tracked entity)
            await _unitOfWork.SaveChangesAsync();
            return Ok(dto);
        }
    }
}
