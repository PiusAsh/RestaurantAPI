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
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Order - Create a new order
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderDTO)
        {
            var response = await _orderService.CreateOrder(orderDTO);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Order - Update an order
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDTO orderDTO)
        {
            var response = await _orderService.UpdateOrder(id, orderDTO);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Order - Delete a specific order by its Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await _orderService.DeleteOrder(id);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Order - Get all available orders
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllOrders(int pageNumber, int pageSize)
        {
            var response = await _orderService.GetAllOrders(pageNumber, pageSize);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Order - Get an order by Id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _orderService.GetOrderById(id);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Order - Get an order by customer Id
        /// </summary>
        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetOrderByCustomerId(int id)
        {
            var response = await _orderService.GetOrderByCustomerId(id);
            return StatusCode(response.StatusCode, response);
        }


        /// <summary>
        /// Order - Get an order by a certain delivery person Id
        /// </summary>
        [HttpGet("deliveryperson/{id}")]
        public async Task<IActionResult> GetOrderByDeliveryPersonId(int id)
        {
            var response = await _orderService.GetOrderByDeliveryPersonId(id);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Order - Get an order by a reference Id
        /// </summary>
        [HttpGet("ref/{id}")]
        public async Task<IActionResult> GetOrderByRef(string id)
        {
            var response = await _orderService.GetOrderByRef(id);
            return StatusCode(response.StatusCode, response);
        }

        /// <summary>
        /// Order - Get an order by a transaction Id
        /// </summary>
        [HttpGet("transaction/{id}")]
        public async Task<IActionResult> GetOrderByTransactionId(string id)
        {
            var response = await _orderService.GetOrderByTransactionId(id);
            return StatusCode(response.StatusCode, response);
        }
    }

}
