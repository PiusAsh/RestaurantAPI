using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using RestaurantAPI.Helpers;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(RestaurantDbContext context, IAuthService authService, IEmailService emailService)
        {
            _context = context;
            _authService = authService;
            _emailService = emailService;
        }



        [HttpPost("login")]
        public async Task<ActionResult<User>> login([FromBody] LoginRequestDto loginRequest)
        {

            var response = await _authService.Login(loginRequest);

            return StatusCode(response.StatusCode, response);
        }



        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            var response = new APIResponse();
            try
            {
                 response = await _authService.Register(userDTO);

                // Send registration confirmation email
                _emailService.SendEmailAsync(userDTO.Email, userDTO.FirstName);

                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {



                response.ResponseMessage = "An error occurred during registration.";
                response.StatusCode = 500;
                response.Data = null;
                response.ErrorMessage = ex.Message;
                

                return StatusCode(response.StatusCode, response);
            }
        }
    }

}

