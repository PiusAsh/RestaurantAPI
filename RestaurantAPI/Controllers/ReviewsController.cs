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

        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var response = await _reviewsService.GetAllReviews();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] ReviewsDTO reviewDTO)
        {
            var response = await _reviewsService.AddReview(reviewDTO);
            return StatusCode(response.StatusCode, response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var response = await _reviewsService.GetReviewById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("food/{foodId}")]
        public async Task<IActionResult> GetReviewsByFoodId(int foodId)
        {
            var response = await _reviewsService.GetReviewsByFoodId(foodId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("commentedby/{commentedById}")]
        public async Task<IActionResult> GetReviewsByCommentedById(int commentedById)
        {
            var response = await _reviewsService.GetReviewsByCommentedById(commentedById);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewsDTO reviewDTO)
        {
            var response = await _reviewsService.UpdateReview(id, reviewDTO);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var response = await _reviewsService.DeleteReview(id);
            return StatusCode(response.StatusCode, response);
        }

    }

}
