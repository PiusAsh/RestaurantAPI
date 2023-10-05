using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;

namespace RestaurantAPI.Entity
{
    public class RestaurantDbContext : DbContext
    {

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options): base(options)
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RestaurantAPI.Entity.Notification> Notification { get; set; }
    }
}
