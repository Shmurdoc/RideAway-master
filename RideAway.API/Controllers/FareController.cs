using Microsoft.AspNetCore.Mvc;
using RideAway.Application.DTOs.Ride;
using RideAway.Application.IServices;
using System.Threading.Tasks;

namespace RideAway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FareController : ControllerBase
    {
        private readonly IFareCalculationService _fareService;
        private readonly IRideMatchingService _rideMatchingService;

        public FareController(
            IFareCalculationService fareService,
            IRideMatchingService rideMatchingService)
        {
            _fareService = fareService;
            _rideMatchingService = rideMatchingService;
        }

        /// <summary>
        /// Estimate fare between two locations.
        /// </summary>
        //[HttpPost("estimate")]
        //public async Task<IActionResult> EstimateFare([FromBody] FareEstimationDTO dto)
        //{
        //    var estimatedFare = await _fareService.CalculateFareAsync(
        //        dto.PickupLocation,
        //        dto.Destination,
        //        dto.EstimatedDistanceKm,
        //        dto.EstimatedTimeMinutes);

        //    dto.EstimatedFare = estimatedFare;
        //    return Ok(dto);
        //}
    }
}
