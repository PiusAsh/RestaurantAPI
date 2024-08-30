using RestaurantAPI.Helpers;
using RestaurantAPI.Models;

namespace RestaurantAPI.Interfaces
{
    public interface INotificationService
    {
        Task<APIResponse> CreateNotification(NotificationDTO notificationDTO);
        Task<APIResponse> UpdateNotification(int id, NotificationDTO notificationDTO);
        Task<APIResponse> DeleteNotification(int id);
        Task<APIResponse> GetAllNotifications(int pageNumber, int pageSize);
        Task<APIResponse> GetNotificationById(int id);
        Task<APIResponse> GetNotificationsByCustomerId(int customerId);
        Task<APIResponse> GetUnreadNotificationsByCustomerId(int customerId);
    }

}
