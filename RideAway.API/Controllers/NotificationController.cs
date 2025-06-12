using Microsoft.AspNetCore.Mvc;
using RideAway.Application.DTOs.Notification;

namespace RideAway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        /// <summary>
        /// Send a notification to a user (stub).
        /// </summary>
        [HttpPost]
        public IActionResult SendNotification([FromBody] NotificationDTO dto)
        {
            // TODO: Integrate with real notification system
            return Ok(new { Message = "Notification sent (stub)." });
        }
    }
}
