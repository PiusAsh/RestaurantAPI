using RestaurantAPI.Helpers;
using RestaurantAPI.Models;

namespace RestaurantAPI.Interfaces
{
    public interface IReviewsService
    {
        Task<APIResponse> AddReview(ReviewsDTO reviewDTO);
        Task<APIResponse> UpdateReview(int id, ReviewsDTO reviewDTO);
        Task<APIResponse> DeleteReview(int id);
        Task<APIResponse> GetReviewById(int id);
        Task<APIResponse> GetReviewsByFoodId(int foodId);
        Task<APIResponse> GetReviewsByCommentedById(int commentedById);
        Task<APIResponse> GetAllReviews();
    }

}
