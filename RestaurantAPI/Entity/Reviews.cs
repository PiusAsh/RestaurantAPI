namespace RestaurantAPI.Entity
{


    // Review.cs
    public class Review
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime PostedDate { get; set; }

    }

}
