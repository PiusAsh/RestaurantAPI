namespace RestaurantAPI.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public decimal Rating { get; set; }
        public bool IsAvailable { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByName { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime DateCreated { get; set; }
        public int LastModifiedBy { get; set; }
        public string Status { get; set; }
    }
}
