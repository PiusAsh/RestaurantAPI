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
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {

            _categoryService = categoryService;
        }

        /// <summary>
        /// Categories - Get all the available categories
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllCategories(int pageNumber, int pageSize)
        {
            var response = await _categoryService.GetCategories(pageNumber, pageSize);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Categories - Get a particular catogory by its Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await _categoryService.GetCategoryById(id);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Categories - Edit a particular catogory
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDTO category)
        {
            var response = await _categoryService.UpdateCategory(id, category);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Categories - Add a new category
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO category)
        {
            var response = await _categoryService.AddCategory(category);
            return StatusCode(response.StatusCode, response);


        }

        /// <summary>
        /// Categories - Delete a category
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _categoryService.DeleteCategory(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
