using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestaurantAPI.Entity;

namespace RestaurantAPI.Models
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Reference { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string TransactionId { get; set; }
        public string ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
        public DeliveryGuy DeliveryGuyDetails { get; set; }
        public List<OrderProduct> Items { get; set; }
        public Customer CustomerDetails { get; set; }
        public string AdditionalMessage { get; set; }
        public string AlternateAddress { get; set; }
        public OrderFulfillmentOption FulfillmentOption { get; set; }
        public List<Notification> Notifications { get; set; }
    }

    public class OrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

    }


    public enum PaymentStatus
    {
        Paid,
        Pending,
        Failed,
        // Add more statuses as needed
    }

    public enum OrderStatus
    {
        Processing,
        Shipped,
        Delivered,
        Cancelled,
        // Add more statuses as needed
    }




    public enum OrderFulfillmentOption
    {
        Shipping,
        SelfPickup,
    }

    public class DeliveryGuy
    {
        public int DeliveryGuyId { get; set; }
        public string DeliveryGuyName { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }

}
