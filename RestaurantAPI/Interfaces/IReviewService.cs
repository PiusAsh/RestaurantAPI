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
        Task<APIResponse> GetReviewsByFoodId(int foodId, int pageNumber, int pageSize);
        Task<APIResponse> GetReviewsByCommentedById(int commentedById, int pageNumber, int pageSize);
        Task<APIResponse> GetAllReviews(int pageNumber, int pageSize);
    }

}
