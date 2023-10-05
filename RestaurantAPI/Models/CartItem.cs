using RestaurantAPI.Entity;

namespace RestaurantAPI.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Product Food { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price => Food.Price;
    }
}
