using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int DeliveryPersonId { get; set; }
        public string Reference { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }

        //public PaymentStatus PaymentStatus { get; set; }
        public string TransactionId { get; set; }
        public string ShippingAddress { get; set; }
        public string OrderStatus { get; set; }

        //public OrderStatus OrderStatus { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedById { get; set; }
        public string AdditionalMessage { get; set; }
        public string AlternateAddress { get; set; }
        public string OrderOption { get; set; }

        //public OrderFulfillmentOption OrderOption { get; set; }
        [NotMapped]
        public DeliveryGuy DeliveryPerson { get; set; }
        [NotMapped]
        public List<OrderProduct> Items { get; set; }
        [NotMapped]
        public Customer CustomerDetails { get; set; }
        public List<Notification> Notifications { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }


    public class OrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class DeliveryGuy
    {
        public int id { get; set; }
        public string Name { get; set; }
    }

    public enum PaymentStatus
    {
        Paid,
        Pending,
        Failed
    }

    public enum OrderStatus
    {
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    public enum OrderFulfillmentOption
    {
        Shipping,
        SelfPickup
    }

}
