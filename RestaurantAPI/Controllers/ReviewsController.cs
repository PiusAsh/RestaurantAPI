using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{

    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsService _reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        /// <summary>
        /// Reviews - Get all reviews
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllReviews(int pageNumber, int pageSize)
        {
            var response = await _reviewsService.GetAllReviews(pageNumber, pageSize);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Reviews - Add a new review
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewsDTO reviewDTO)
        {
            var response = await _reviewsService.AddReview(reviewDTO);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Reviews - Get a single review
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var response = await _reviewsService.GetReviewById(id);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Reviews - Get a review base on food Id
        /// </summary>
        [HttpGet("food/{foodId}")]
        public async Task<IActionResult> GetReviewsByFoodId(int foodId, int pageNumber, int pageSize)
        {
            var response = await _reviewsService.GetReviewsByFoodId(foodId, pageNumber, pageSize);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Reviews - Get a review by Commented by Id
        /// </summary>
        [HttpGet("commentedby/{commentedById}")]
        public async Task<IActionResult> GetReviewsByCommentedById(int commentedById, int pageNumber, int pageSize)
        {
            var response = await _reviewsService.GetReviewsByCommentedById(commentedById, pageNumber, pageSize);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Reviews - Update a review by Id
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewsDTO reviewDTO)
        {
            var response = await _reviewsService.UpdateReview(id, reviewDTO);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Reviews - Delete a review by Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var response = await _reviewsService.DeleteReview(id);
            return StatusCode(response.StatusCode, response);
        }

    }

}
