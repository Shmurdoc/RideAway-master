using Microsoft.AspNetCore.Mvc;
using RideAway.Application.DTOs.Driver;
using RideAway.Application.IRepositories;

namespace RideAway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverDispatchController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DriverDispatchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get incoming ride requests for a driver (stub).
        /// </summary>
        [HttpGet("requests/{driverId}")]
        public IActionResult GetIncomingRequests(Guid driverId)
        {
            // TODO: Implement real ride request dispatch logic
            return Ok(new[]
            {
                new DispatchRequestDTO
                {
                    RequestId = Guid.NewGuid(),
                    DriverId = driverId,
                    RideId = Guid.NewGuid(),
                    PickupLocation = "123 Mopani St, Phalaborwa",
                    Destination = "456 Baobab Ave, Phalaborwa",
                    RequestedAt = DateTime.UtcNow,
                    IsAccepted = false
                }
            });
        }

        /// <summary>
        /// Accept or reject a ride request (stub).
        /// </summary>
        [HttpPost("respond")]
        public IActionResult RespondToRequest([FromBody] DispatchRequestDTO dto)
        {
            // TODO: Implement real accept/reject logic
            return Ok(new { Message = dto.IsAccepted ? "Ride accepted." : "Ride rejected." });
        }
    }
}
