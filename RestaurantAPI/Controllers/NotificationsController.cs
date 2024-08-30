using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Notification - Create a new notification
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationDTO notificationDTO)
        {
            var response = await _notificationService.CreateNotification(notificationDTO);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Notification - Edit or update a notification
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, [FromBody] NotificationDTO notificationDTO)
        {
            var response = await _notificationService.UpdateNotification(id, notificationDTO);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Notification - Delete a notification
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var response = await _notificationService.DeleteNotification(id);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Notification - Get all available notifications
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllNotifications(int pageNumber, int pageSize)
        {
            var response = await _notificationService.GetAllNotifications(pageNumber, pageSize);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Notification - Get a notification by its Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var response = await _notificationService.GetNotificationById(id);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Notification - Get a notification by customer Id
        /// </summary>
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetNotificationsByCustomerId(int customerId)
        {
            var response = await _notificationService.GetNotificationsByCustomerId(customerId);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Notification - Get an unread notification for a specific customer
        /// </summary>
        [HttpGet("unread/customer/{customerId}")]
        public async Task<IActionResult> GetUnreadNotificationsByCustomerId(int customerId)
        {
            var response = await _notificationService.GetUnreadNotificationsByCustomerId(customerId);
            return StatusCode(response.StatusCode, response);
        }
    }

}

