using RestaurantAPI.Entity;
using RestaurantAPI.Models;

namespace RestaurantAPI.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        //Task UpdateUserAsync(int id, User user);
        Task UpdateUserAsync(int id, UserDTO user);
        Task DeleteUserAsync(int id);

    }
}
