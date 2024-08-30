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
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Products - Get all available products
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(int pageNumber, int pageSize)
        {
            var response = await _productService.GetAllProductsAsync(pageNumber, pageSize);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Products - Add a new product
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDTO)
        {
            var response = await _productService.AddProductAsync(productDTO);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Products - Update an existing product
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            var response = await _productService.UpdateProductAsync(id, productDTO);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Products - Delete a product by Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProductAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Products - Get a product by Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await _productService.GetProductAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }

}
