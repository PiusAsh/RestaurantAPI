namespace RestaurantAPI.Models
{
    public class ReviewsDTO
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int CommentedById { get; set; }
        public string CommentedByName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime PostedDate { get; set; }
    }



}
