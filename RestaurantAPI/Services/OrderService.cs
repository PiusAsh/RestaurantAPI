using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using RestaurantAPI.Helpers;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<APIResponse> CreateOrder(OrderDTO orderDTO)
        {
            var response = new APIResponse();

            try
            {
                var order = new Order
                {
                    // Map properties from orderDTO to Order entity
                    CustomerId = orderDTO.CustomerId,
                    Reference = orderDTO.Reference,
                    OrderDate = orderDTO.OrderDate,
                    TotalAmount = orderDTO.TotalAmount,
                    PaymentStatus = orderDTO.PaymentStatus,
                    TransactionId = orderDTO.TransactionId,
                    ShippingAddress = orderDTO.ShippingAddress,
                    OrderStatus = orderDTO.OrderStatus,
                    AdditionalMessage = orderDTO.AdditionalMessage,
                    AlternateAddress = orderDTO.AlternateAddress,
                    OrderOption = orderDTO.OrderOption,
                    Items = orderDTO.Items, // Assuming orderDTO.Items is a list of OrderProduct
                    Notifications = orderDTO.Notifications, // Assuming orderDTO.Notifications is a list of Notification
                    CustomerDetails = orderDTO.CustomerDetails,
                    
                };

                var NewOrder = _mapper.Map<Order>(orderDTO);
                _context.Add(NewOrder);
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Order Created Successfully";
                response.StatusCode = 200;
                response.Data = orderDTO;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while creating the order.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public async Task<APIResponse> DeleteOrder(int id)
        {
            var response = new APIResponse();

            try
            {
                var existingOrder = await _context.Orders.FindAsync(id);

                if (existingOrder == null)
                {
                    response.ResponseMessage = "Order not found";
                    response.StatusCode = 404;
                    return response;
                }

                _context.Orders.Remove(existingOrder);
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Order Deleted Successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while deleting the order.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetAllOrders()
        {
            var response = new APIResponse();

            try
            {
                var orders = await _context.Orders.ToListAsync();

                response.ResponseMessage = "Orders retrieved successfully";
                response.StatusCode = 200;
                response.Data = orders; // Assuming orders is a list of Order
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the orders.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public async Task<APIResponse> GetOrderByCustomerId(int customerId)
        {
            var response = new APIResponse();

            try
            {
                var orders = await _context.Orders
                            .Where(order => order.CustomerId == customerId)
                            .ToListAsync();

                response.ResponseMessage = "Orders Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = orders; // Assuming orders is a list of Order
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the orders.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public async Task<APIResponse> GetOrderByProductId(int productId)
        {
            var response = new APIResponse();

            try
            {
                var orders = await _context.Orders.Where(order => order.ProductId == productId).ToListAsync();

                response.ResponseMessage = "Orders Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = orders; // Assuming orders is a list of Order
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the orders.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetOrderByDeliveryPersonId(int deliveryPersonId)
        {
            var response = new APIResponse();

            try
            {
                var orders = await _context.Orders.Where(order => order.DeliveryPersonId == deliveryPersonId).ToListAsync();

                response.ResponseMessage = "Orders Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = orders; // Assuming orders is a list of Order
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the orders.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public async Task<APIResponse> GetOrderById(int id)
        {
            var response = new APIResponse();

            try
            {
                var order = await _context.Orders.FindAsync(id);

                if (order == null)
                {
                    response.ResponseMessage = "Order not found";
                    response.StatusCode = 404;
                    return response;
                }

                response.ResponseMessage = "Order Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = order;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the order.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public async Task<APIResponse> GetOrderByRef(string reference)
        {
            var response = new APIResponse();

            try
            {
                var order = await _context.Orders.Where(p => p.Reference == reference).ToListAsync();

                if (order == null)
                {
                    response.ResponseMessage = "Order not found";
                    response.StatusCode = 404;
                    return response;
                }

                response.ResponseMessage = "Order retrieved successfully";
                response.StatusCode = 200;
                response.Data = order;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the order.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public async Task<APIResponse> GetOrderByTransactionId(string transactionId)
        {
            var response = new APIResponse();

            try
            {

                var order = await _context.Orders.Where(order => order.TransactionId == transactionId).ToListAsync();

                if (order == null)
                {
                    response.ResponseMessage = "Order not found";
                    response.StatusCode = 404;
                    return response;
                }

                response.ResponseMessage = "Order Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = order;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the order.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


        public async Task<APIResponse> UpdateOrder(int id, OrderDTO orderDTO)
        {
            var response = new APIResponse();

            try
            {
                var existingOrder = await _context.Orders.FindAsync(id);

                if (existingOrder == null)
                {
                    response.ResponseMessage = "Order not found";
                    response.StatusCode = 404;
                    return response;
                }

                // Update properties of existingOrder with values from orderDTO
                existingOrder.CustomerId = orderDTO.CustomerId;
                existingOrder.Reference = orderDTO.Reference;
                existingOrder.OrderDate = orderDTO.OrderDate;
                existingOrder.TotalAmount = orderDTO.TotalAmount;
                existingOrder.PaymentStatus = orderDTO.PaymentStatus;
                existingOrder.TransactionId = orderDTO.TransactionId;
                existingOrder.ShippingAddress = orderDTO.ShippingAddress;
                existingOrder.OrderStatus = orderDTO.OrderStatus;
                existingOrder.LastModifiedDate = DateTime.Now; 
                existingOrder.LastModifiedById = orderDTO.LastModifiedById;
                existingOrder.AdditionalMessage = orderDTO.AdditionalMessage;
                existingOrder.AlternateAddress = orderDTO.AlternateAddress;
                existingOrder.OrderOption = orderDTO.OrderOption;
                existingOrder.Items = orderDTO.Items; 
                existingOrder.Notifications = orderDTO.Notifications;
                existingOrder.CustomerDetails = orderDTO.CustomerDetails;
                existingOrder.DeliveryPerson = orderDTO.DeliveryPerson;


                // Check if any properties have been modified
                var isAnyPropertyModified = _context.Entry(existingOrder).Properties.Any(p => p.IsModified);

                if (!isAnyPropertyModified)
                {
                    response.ResponseMessage = "No Changes Made";
                    response.StatusCode = 200;
                    return response;
                }
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Order Updated Successfully";
                response.StatusCode = 200;
                response.Data = orderDTO;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while updating the order.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

    }

}
