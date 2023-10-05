using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using RestaurantAPI.Helpers;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        private readonly IUserService _userService;

        public UsersController(RestaurantDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet("AllUsers")]
        public async Task<ActionResult<APIResponse>> GetUsers()
        {
            var Response = new APIResponse();
            try
            {
                var users = await _userService.GetAllUsersAsync();
                if (users.Any())
                {
                    Response.StatusCode = 200;
                    Response.ResponseMessage = "Users Retrieved Successfully.";
                    Response.Data = users;
                    return Ok(Response);
                }
                else
                {
                    Response.StatusCode = 404;
                    Response.ResponseMessage = "No User Found.";
                    return NotFound(Response.ResponseMessage);
                }

            }
            catch (Exception ex)
            {

                Response.StatusCode = 500;
                Response.ResponseMessage = "An error occurred while retrieving Users.";
                Response.Data = ex.Message;

                return StatusCode(500, Response);
            }

        }

        // GET: api/Users/5
        [HttpGet("GetUserById{id}")]
        public async Task<ActionResult<APIResponse>> GetUser(int id)
        {
            var response = new APIResponse();

            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    response.StatusCode = 404;
                    response.ResponseMessage = "User with the provided Id not found.";
                    return NotFound(response);
                }
                response.StatusCode = 200;
                response.ResponseMessage = "User Retrieved successfully.";
                response.Data = user;
                return Ok(response);
            }
            catch (Exception ex)
            {

                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while retrieving the Room.";
                response.Data = ex.Message;

                return StatusCode(500, response);
            }

        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update{id}")]
        public async Task<ActionResult<APIResponse>> UpdateUser(int id, User user)
        {
            var response = new APIResponse();
            try
            {
                var userDetails = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    response.StatusCode = 404;
                    response.ResponseMessage = "User not found.";
                    return NotFound(response);
                }

                response.StatusCode = 200;
                response.ResponseMessage = "User Updated Successfully.";
                response.Data = userDetails;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while updating the Room.";
                response.Data = ex.Message;

                return StatusCode(500, response);
            }

        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("Add")]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //}

        // DELETE: api/Users/5
        [HttpDelete("Delete{id}")]
        public async Task<ActionResult<APIResponse>> DeleteUser(int id)
        {
            var response = new APIResponse();

            try
            {
                 await _userService.DeleteUserAsync(id);
                response.StatusCode = 200;
                response.ResponseMessage = "User Deleted Successfully.";

                return Ok(response);
            }
            catch (Exception ex)
            {

                response.StatusCode = 500;
                response.ResponseMessage = "An error occurred while deleting the Room.";
                response.Data = ex.Message; // You can include more details if needed

                return StatusCode(500, response);
            }
        }
    }
}
