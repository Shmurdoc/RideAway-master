using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RideAway.Application.DTOs.Ride;
using RideAway.Application.DTOs.User;
using RideAway.Application.DTOs.Notification;
using RideAway.Application.IRepositories;
using RideAway.Application.IServices.INotification;
using RideAway.Domain.Entities;

namespace RideAway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;

        public TrackingController(IUnitOfWork unitOfWork, INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
           
        }

        /// <summary>
        /// Update the driver's current location for a ride (real-time tracking).
        /// </summary>
        [HttpPost("update-location")]
        public async Task<IActionResult> UpdateLocation([FromBody] DriverLocationUpdateDTO dto)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(dto.DriverId);
            if (user == null)
                return NotFound("Driver not found.");

            user.CurrentLocation = dto.CurrentLocation;
            await _unitOfWork.SaveChangesAsync();

            // Trigger notification via SignalR
            //await _hubContext.Clients.Group(dto.DriverId.ToString()).SendAsync("ReceiveLocationUpdate", new
            //{
            //    DriverId = dto.DriverId,
            //    CurrentLocation = dto.CurrentLocation
            //});

            var notification = new NotificationDTO
            {
                NotificationId = Guid.NewGuid(),
                UserId = user.Id, // In production, set to the rider's ID
                Message = $"Driver location updated: {dto.CurrentLocation}",
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };
            await _notificationService.SendNotificationAsync(notification);

            return Ok(new { Message = "Location updated and notification sent." });
        }

        /// <summary>
        /// Get real-time tracking info for a ride.
        /// </summary>
        [HttpGet("{rideId}")]
        public async Task<IActionResult> GetTracking(Guid rideId)
        {
            var ride = await _unitOfWork.RideRepository.GetByIdAsync(rideId);
            if (ride == null)
                return NotFound();

            var tracking = new RideTrackingDTO
            {
                RideId = ride.Id,
                CurrentLocation = ride.PickupLocation, // Replace with real-time location if available
                Destination = ride.Destination,
                ProgressPercent = CalculateProgress(ride),
                LastUpdated = DateTime.UtcNow
            };

            return Ok(tracking);
        }

        private int CalculateProgress(Ride ride)
        {
            // Stub: Implement logic to calculate progress percentage based on route
            return 0;
        }
    }
}
