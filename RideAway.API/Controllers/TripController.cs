using Microsoft.AspNetCore.Mvc;
using RideAway.Application.DTOs.Ride;
using RideAway.Application.IRepositories;
using System.Security.Claims;

namespace RideAway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TripController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get trip history for the current user (rider or driver).
        /// </summary>
        [HttpGet("history")]
        public async Task<IActionResult> GetTripHistory()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null || !Guid.TryParse(userIdClaim, out var userId))
                return Unauthorized();
            // For demo: get all rides where user is rider or driver
            var rides = await _unitOfWork.RideRepository.GetAllAsync(r => r.RiderId == userId || r.DriverId == userId);
            var history = rides.Select(r => new TripHistoryDTO
            {
                RideId = r.Id,
                RiderId = r.RiderId,
                DriverId = r.DriverId,
                PickupLocation = r.PickupLocation,
                Destination = r.Destination,
                RideDate = r.CreatedAt,
                Fare = r.Fare,
                Rating = null, // Add if available
                Feedback = null // Add if available
            }).ToList();
            return Ok(history);
        }

        /// <summary>
        /// Submit feedback for a ride.
        /// </summary>
        [HttpPost("feedback")]
        public async Task<IActionResult> SubmitFeedback([FromBody] FeedbackDTO dto)
        {
            // TODO: Save feedback to DB (add Feedback entity/table if needed)
            // For now, just return success
            return Ok(new { Message = "Feedback submitted." });
        }
    }
}
