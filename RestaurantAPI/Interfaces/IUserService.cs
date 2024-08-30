using RestaurantAPI.Entity;
using RestaurantAPI.Helpers;
using RestaurantAPI.Models;

namespace RestaurantAPI.Interfaces
{
    public interface IUserService
    {
       
        Task<APIResponse> UpdateUserAsync(int id, UserDTO userDTO);
        Task<APIResponse> DeleteUserAsync(int id);
        Task<APIResponse> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<APIResponse> GetUserByIdAsync(int id);
        Task<APIResponse> GetUserByEmailAsync(string email);

    }

}
