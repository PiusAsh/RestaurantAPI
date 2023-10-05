using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using RestaurantAPI.Helpers;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public ReviewsService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<APIResponse> AddReview(ReviewsDTO reviewDTO)
        {
            var response = new APIResponse();

            try
            {
                var entity = new Review
                {
                    FoodId = reviewDTO.FoodId,
                    CommentedById = reviewDTO.CommentedById,
                    CommentedByName = reviewDTO.CommentedByName,
                    Rating = reviewDTO.Rating,
                    Comment = reviewDTO.Comment,
                    PostedDate = reviewDTO.PostedDate
                };

                //var entity = _mapper.Map<Review>(reviewDTO);
                _context.Reviews.Add(entity);
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Review Added Successfully";
                response.StatusCode = 200;
                response.Data = reviewDTO;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while adding the review.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> UpdateReview(int id, ReviewsDTO reviewDTO)
        {
            var response = new APIResponse();

            try
            {
                var existingReview = await _context.Reviews.FindAsync(id);

                if (existingReview == null)
                {
                    response.ResponseMessage = "Review not found";
                    response.StatusCode = 404;
                    return response;
                }

                // Update properties of existingReview with values from reviewDTO
                existingReview.FoodId = reviewDTO.FoodId;
                existingReview.CommentedById = reviewDTO.CommentedById;
                existingReview.CommentedByName = reviewDTO.CommentedByName;
                existingReview.Rating = reviewDTO.Rating;
                existingReview.Comment = reviewDTO.Comment;
                existingReview.PostedDate = reviewDTO.PostedDate;

                await _context.SaveChangesAsync();

                response.ResponseMessage = "Review Updated Successfully";
                response.StatusCode = 200;
                response.Data = reviewDTO;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while updating the review.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> DeleteReview(int id)
        {
            var response = new APIResponse();

            try
            {
                var review = await _context.Reviews.FindAsync(id);

                if (review == null)
                {
                    response.ResponseMessage = "Review not found";
                    response.StatusCode = 404;
                    return response;
                }

                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();

                response.ResponseMessage = "Review Deleted Successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while deleting the review.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetReviewById(int id)
        {
            var response = new APIResponse();

            try
            {
                var review = await _context.Reviews.FindAsync(id);

                if (review == null)
                {
                    response.ResponseMessage = "Review not found";
                    response.StatusCode = 404;
                    return response;
                }

                var reviewDTO = new ReviewsDTO
                {
                    Id = review.Id,
                    FoodId = review.FoodId,
                    CommentedById = review.CommentedById,
                    CommentedByName = review.CommentedByName,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    PostedDate = review.PostedDate
                };

                response.ResponseMessage = "Review Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = reviewDTO;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the review.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetReviewsByFoodId(int foodId)
        {
            var response = new APIResponse();

            try
            {
                var reviews = await _context.Reviews
                    .Where(r => r.FoodId == foodId)
                    .ToListAsync();

                var reviewDTOs = reviews.Select(review => new ReviewsDTO
                {
                    Id = review.Id,
                    FoodId = review.FoodId,
                    CommentedById = review.CommentedById,
                    CommentedByName = review.CommentedByName,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    PostedDate = review.PostedDate
                }).ToList();

                response.ResponseMessage = "Reviews Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = reviewDTOs;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the reviews.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetReviewsByCommentedById(int commentedById)
        {
            var response = new APIResponse();

            try
            {
                var reviews = await _context.Reviews
                    .Where(r => r.CommentedById == commentedById)
                    .ToListAsync();

                var reviewDTOs = reviews.Select(review => new ReviewsDTO
                {
                    Id = review.Id,
                    FoodId = review.FoodId,
                    CommentedById = review.CommentedById,
                    CommentedByName = review.CommentedByName,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    PostedDate = review.PostedDate
                }).ToList();

                response.ResponseMessage = "Reviews Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = reviewDTOs;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the reviews.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }




        public async Task<APIResponse> GetAllReviews()
        {
            var response = new APIResponse();

            try
            {
                var reviews = await _context.Reviews.ToListAsync();

                var reviewDTOs = reviews.Select(review => new ReviewsDTO
                {
                    Id = review.Id,
                    FoodId = review.FoodId,
                    CommentedById = review.CommentedById,
                    CommentedByName = review.CommentedByName,
                    Rating = review.Rating,
                    Comment = review.Comment,
                    PostedDate = review.PostedDate
                }).ToList();

                response.ResponseMessage = "Reviews retrieved successfully";
                response.StatusCode = 200;
                response.Data = reviewDTOs;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the reviews.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


    }


}
