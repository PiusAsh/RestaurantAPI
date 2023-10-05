using RestaurantAPI.Helpers;
using RestaurantAPI.Models;

namespace RestaurantAPI.Interfaces
{
    public interface IAuthService
    {
        Task<APIResponse> Register(UserDTO userDTO);
        Task<APIResponse> Login(LoginRequestDto loginRequest);
    }
}
