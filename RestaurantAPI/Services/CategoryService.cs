using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using RestaurantAPI.Helpers;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(RestaurantDbContext restaurantDb, IMapper mapper)
        {
            _context = restaurantDb;
            _mapper = mapper;
        }

        public async Task<APIResponse> AddCategory(CategoryDTO category)
        {
            var response = new APIResponse();

            var categoryExist = await _context.Categories.FirstOrDefaultAsync(p => p.Name.ToLower() == category.Name.ToLower());
            if (categoryExist != null)
            {
                response.ResponseMessage = "Category Already Exists";
                response.StatusCode = 400;
                return response;
            }

            var entity = new Category
            {
                Name = category.Name,
                Description = category.Description,
                DateCreated = DateTime.Now,
                CreatedByName = category.CreatedByName,
                CreatedByUserId = category.CreatedByUserId,
                Status = "Active"
            };

            try
            {
                _context.Categories.Add(entity);
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Category Added Successfully";
                response.StatusCode = 200;
                response.Data = category;

                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while adding the Category";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                return response;
            }
        }

        public async Task<APIResponse> DeleteCategory(int id)
        {
            var response = new APIResponse();

            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    response.ResponseMessage = "Category Not Found";
                    response.StatusCode = 404;
                    return response;
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Category Deleted Successfully";
                response.StatusCode = 200;

                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while delete the Category";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                return response;
            }
        }

        public async Task<APIResponse> GetCategories()
        {
            var category = await _context.Categories.ToListAsync();
            var response = new APIResponse
            {
                StatusCode = 200,
                ResponseMessage = "Success",
                Data = category
            };
            return response;
        }

        public async Task<APIResponse> GetCategoryById(int id)
        {
            var response = new APIResponse();

            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                {
                    response.ResponseMessage = "Category Not Found";
                    response.StatusCode = 404;
                    return response;
                }

                var categoryDTO = _mapper.Map<CategoryDTO>(category);

                response.ResponseMessage = "Category Found";
                response.StatusCode = 200;
                response.Data = categoryDTO;

                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the Category";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                return response;
            }
        }

        public async Task<APIResponse> UpdateCategory(int id, CategoryDTO category)
        {
            var response = new APIResponse();
            var existingCategory = await _context.Categories.FindAsync(id);

            if (existingCategory == null)
            {
                response.ResponseMessage = "Category Not Found.";
                response.StatusCode = 404;
                return response;
            }
            if(category.Name == existingCategory.Name && category.Description == existingCategory.Description)
            {
                response.ResponseMessage = "No Changes Made.";
                response.StatusCode = 200;
                return response;
            }
            else
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
            }
            try
            {
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Category Updated Successfully.";
                response.StatusCode = 200;
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while updating the Category.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
                return response;
            }
        }
    }
}
