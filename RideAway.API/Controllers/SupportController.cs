using Microsoft.AspNetCore.Mvc;
using RideAway.Application.DTOs.Support;

namespace RideAway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupportController : ControllerBase
    {
        /// <summary>
        /// Send a support chat message (stub).
        /// </summary>
        [HttpPost("chat")]
        public IActionResult SendSupportChat([FromBody] SupportChatDTO dto)
        {
            // TODO: Integrate with real support chat/helpdesk system
            return Ok(new { Message = "Support chat message sent (stub)." });
        }
    }
}
