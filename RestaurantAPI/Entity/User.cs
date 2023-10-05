namespace RestaurantAPI.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string Status { get; set; }
    }



    public enum UserRole
    {
        Customer,
        Delivery,
        Moderator,
        Admin,

        // Add more roles as needed
    }

}
