using RestaurantAPI.Helpers;
using RestaurantAPI.Models;

namespace RestaurantAPI.Interfaces
{
    public interface IOrderService
    {
        Task<APIResponse> CreateOrder(OrderDTO orderDTO);
        Task<APIResponse> UpdateOrder(int id, OrderDTO orderDTO);
        Task<APIResponse> DeleteOrder(int id);
        Task<APIResponse> GetAllOrders(int pageNumber, int pageSize);
        Task<APIResponse> GetOrderById(int id);
        Task<APIResponse> GetOrderByCustomerId(int customerId);
        Task<APIResponse> GetOrderByDeliveryPersonId(int deliveryPersonId);
        Task<APIResponse> GetOrderByRef(string reference);
        Task<APIResponse> GetOrderByProductId(int productId);
        Task<APIResponse> GetOrderByTransactionId(string transactionId);
    }

}
