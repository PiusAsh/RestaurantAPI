using RestaurantAPI.Helpers;
using RestaurantAPI.Models;

namespace RestaurantAPI.Interfaces
{
    public interface IProductService
    {
        Task<APIResponse> AddProductAsync(ProductDTO productDTO);
        Task<APIResponse> UpdateProductAsync(int id, ProductDTO productDTO);
        Task<APIResponse> DeleteProductAsync(int id);
        Task<APIResponse> GetProductAsync(int id);
        Task<APIResponse> GetAllProductsAsync();
    }


}
