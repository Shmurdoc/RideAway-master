using Microsoft.AspNetCore.Mvc;
using RideAway.Application.DTOs.Driver;
using RideAway.Application.IRepositories;

namespace RideAway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverDashboardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DriverDashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get driver earnings summary.
        /// </summary>
        [HttpGet("earnings/{driverId}")]
        public IActionResult GetEarnings(Guid driverId)
        {
            // TODO: Implement real earnings calculation
            var earnings = new EarningsDTO
            {
                DriverId = driverId,
                TotalEarnings = 0,
                PendingPayout = 0,
                LastPayoutDate = DateTime.UtcNow
            };
            return Ok(earnings);
        }

        /// <summary>
        /// Get driver ratings and performance.
        /// </summary>
        [HttpGet("ratings/{driverId}")]
        public IActionResult GetRatings(Guid driverId)
        {
            // TODO: Implement real ratings aggregation
            var ratings = new DriverRatingDTO
            {
                DriverId = driverId,
                AverageRating = 0,
                TotalRides = 0,
                Compliments = 0,
                Complaints = 0
            };
            return Ok(ratings);
        }
    }
}
