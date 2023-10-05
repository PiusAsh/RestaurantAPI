namespace RestaurantAPI.Entity
{
    public class Notification
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime DateReceived { get; set; }
    }
}
