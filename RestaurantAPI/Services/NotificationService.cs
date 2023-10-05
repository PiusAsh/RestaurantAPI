using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using RestaurantAPI.Helpers;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public NotificationService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<APIResponse> CreateNotification(NotificationDTO notificationDTO)
        {
            var response = new APIResponse();

            try
            {
                var entity = _mapper.Map<Notification>(notificationDTO);

                _context.Notifications.Add(entity);
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Notification created successfully";
                response.StatusCode = 200;
                response.Data = entity;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while creating the notification.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> UpdateNotification(int id, NotificationDTO notificationDTO)
        {
            var response = new APIResponse();

            try
            {
                var existingNotification = await _context.Notifications.FindAsync(id);

                if (existingNotification == null)
                {
                    response.ResponseMessage = "Notification not found";
                    response.StatusCode = 404;
                    return response;
                }

                // Map properties from notificationDTO to existingNotification
                _mapper.Map(notificationDTO, existingNotification);

                await _context.SaveChangesAsync();

                response.ResponseMessage = "Notification Updated Successfully";
                response.StatusCode = 200;
                response.Data = notificationDTO;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while updating the notification.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> DeleteNotification(int id)
        {
            var response = new APIResponse();

            try
            {
                var existingNotification = await _context.Notifications.FindAsync(id);

                if (existingNotification == null)
                {
                    response.ResponseMessage = "Notification not found";
                    response.StatusCode = 404;
                    return response;
                }

                _context.Notifications.Remove(existingNotification);
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Notification Deleted Successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while deleting the notification.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetAllNotifications()
        {
            var response = new APIResponse();

            try
            {
                var notifications = await _context.Notifications.OrderByDescending(p => p.Id).ToListAsync();
                response.ResponseMessage = "Notifications Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = notifications;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the notifications.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetNotificationById(int id)
        {
            var response = new APIResponse();

            try
            {
                var notification = await _context.Notifications.FindAsync(id);

                if (notification == null)
                {
                    response.ResponseMessage = "Notification not found";
                    response.StatusCode = 404;
                    return response;
                }

                response.ResponseMessage = "Notification Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = notification;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the notification.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetNotificationsByCustomerId(int customerId)
        {
            var response = new APIResponse();

            try
            {
                var notifications = await _context.Notifications
                    .Where(n => n.CustomerId == customerId)
                    .ToListAsync();

                response.ResponseMessage = "Notifications Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = notifications;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the notifications.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetUnreadNotificationsByCustomerId(int customerId)
        {
            var response = new APIResponse();

            try
            {
                var notifications = await _context.Notifications
                    .Where(n => n.CustomerId == customerId && !n.IsRead)
                    .ToListAsync();

                response.ResponseMessage = $" {notifications.Count} Unread notifications"; ;
                response.StatusCode = 200;
                response.Data = notifications;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the unread notifications.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }

}
