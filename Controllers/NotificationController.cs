using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartGymAPI.Services;

namespace SmartGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserNotification(int userId) 
        {
            var notification = await _notificationService.GetUserNotifications(userId);
            return Ok(notification);
        }
        [HttpPut("mark-read/{id}")]
        public async Task<IActionResult>MarkAsRead(int id)
        {
            await _notificationService.MarkAsRead(id);
            return Ok();
        }
    }
}
