using MediTrack.Models;
using MediTrack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // GET: api/Notifications/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Notification>> GetNotificationById(int id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
                return NotFound();

            return Ok(notification);
        }

        // GET: api/Notifications/User/5
        [HttpGet("User/{userId:int}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetNotificationsByUser(int userId)
        {
            var notifications = await _notificationService.GetNotificationsByUserAsync(userId);
            return Ok(notifications);
        }

        // POST: api/Notifications
        [HttpPost]
        public async Task<ActionResult<Notification>> SendNotification([FromBody] Notification notification)
        {
            if (notification == null)
                return BadRequest("Notification cannot be null.");

            var sentNotification = await _notificationService.SendNotificationAsync(notification);
            return CreatedAtAction(nameof(GetNotificationById), new { id = sentNotification.NotificationId }, sentNotification);
        }

        // PUT: api/Notifications/5/Read
        [HttpPut("{id:int}/Read")]
        public async Task<ActionResult> MarkAsRead(int id)
        {
            var result = await _notificationService.MarkAsReadAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
