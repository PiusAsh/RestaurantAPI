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

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderDTO)
        {
            var response = await _orderService.CreateOrder(orderDTO);
            return StatusCode(response.StatusCode, response);
        }

        // PUT: api/orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDTO orderDTO)
        {
            var response = await _orderService.UpdateOrder(id, orderDTO);
            return StatusCode(response.StatusCode, response);
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await _orderService.DeleteOrder(id);
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var response = await _orderService.GetAllOrders();
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _orderService.GetOrderById(id);
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/orders/customer/5
        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetOrderByCustomerId(int id)
        {
            var response = await _orderService.GetOrderByCustomerId(id);
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/orders/deliveryperson/5
        [HttpGet("deliveryperson/{id}")]
        public async Task<IActionResult> GetOrderByDeliveryPersonId(int id)
        {
            var response = await _orderService.GetOrderByDeliveryPersonId(id);
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/orders/ref/ABC123
        [HttpGet("ref/{id}")]
        public async Task<IActionResult> GetOrderByRef(string id)
        {
            var response = await _orderService.GetOrderByRef(id);
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/orders/transaction/XYZ456
        [HttpGet("transaction/{id}")]
        public async Task<IActionResult> GetOrderByTransactionId(string id)
        {
            var response = await _orderService.GetOrderByTransactionId(id);
            return StatusCode(response.StatusCode, response);
        }
    }

}
