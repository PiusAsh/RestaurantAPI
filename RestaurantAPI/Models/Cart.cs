using RestaurantAPI.Entity;

namespace RestaurantAPI.Models
{
    public class Cart
    {
        public User User { get; set; } = new User();
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalPrice => Items.Sum(item => item.Price);
        public int TotalCount => Items.Sum(item => item.Quantity);
    }
}
