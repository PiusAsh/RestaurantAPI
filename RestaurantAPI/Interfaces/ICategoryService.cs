using RestaurantAPI.Helpers;
using RestaurantAPI.Models;

namespace RestaurantAPI.Interfaces
{
    public interface ICategoryService
    {
        Task<APIResponse> AddCategory(CategoryDTO category);
        Task<APIResponse> UpdateCategory(int id, CategoryDTO category);
        Task<APIResponse> DeleteCategory(int id);
        Task<APIResponse> GetCategoryById(int id);
        Task<APIResponse> GetCategories();
    }
}
