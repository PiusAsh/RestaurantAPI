namespace RestaurantAPI.Interfaces
{

    public interface IEmailService
    {
        void SendEmailAsync(string to, string username);
    }

}


