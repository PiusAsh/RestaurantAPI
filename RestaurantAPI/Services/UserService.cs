using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using RestaurantAPI.Helpers;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{

    public class UserService : IUserService
    {

        private readonly RestaurantDbContext _context;

        public UserService(RestaurantDbContext context)
        {

            _context = context;
        }



        public async Task<APIResponse> UpdateUserAsync(int id, UserDTO userDTO)
        {
            var response = new APIResponse();

            var entity = await _context.Users.FindAsync(id);
            if (entity == null)
            {
                response.ResponseMessage = "User not found";
                response.StatusCode = 404;
                return response;
            }

            // Update properties of existingUser with values from userDTO
            entity.FirstName = userDTO.FirstName;
            entity.LastName = userDTO.LastName;
            entity.Gender = userDTO.Gender;
            entity.Email = userDTO.Email;
            entity.PhoneNo = userDTO.PhoneNo;
            entity.Address = userDTO.Address;
            entity.DateOfBirth = userDTO.DateOfBirth;
            entity.State = userDTO.State;
            entity.Country = userDTO.Country;
            entity.LastModifiedDate = DateTime.UtcNow;

            try
            {
                var isAnyPropertyModified = _context.Entry(entity).Properties.Any(p => p.IsModified);

                if (!isAnyPropertyModified)
                {
                    response.ResponseMessage = "No Changes Made";
                    response.StatusCode = 200;
                    return response;
                }

                await _context.SaveChangesAsync();
                response.ResponseMessage = "User Updated Successfully";
                response.StatusCode = 200;
                response.Data = userDTO;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while updating the user.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }



        public async Task<APIResponse> DeleteUserAsync(int id)
        {
            var response = new APIResponse();

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                response.ResponseMessage = "User not found";
                response.StatusCode = 404;
                return response;
            }

            try
            {
                _context.Users.Remove(existingUser);
                await _context.SaveChangesAsync();
                response.ResponseMessage = "User Deleted Successfully";
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while deleting the user.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetAllUsersAsync()
        {
            var response = new APIResponse();

            try
            {
                var users = await _context.Users.OrderByDescending(p => p.Id).ToListAsync();
                response.ResponseMessage = "Users Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = users;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the users.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetUserByIdAsync(int id)
        {
            var response = new APIResponse();

            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    response.ResponseMessage = "User not found";
                    response.StatusCode = 404;
                    return response;
                }

                response.ResponseMessage = "User Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = user;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the user.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<APIResponse> GetUserByEmailAsync(string email)
        {
            var response = new APIResponse();

            try
            {
                var user = await _context.Users.Where(p => p.Email == email).ToListAsync();
                if (user == null)
                {
                    response.ResponseMessage = "User not found";
                    response.StatusCode = 404;
                    return response;
                }

                response.ResponseMessage = "User Retrieved Successfully";
                response.StatusCode = 200;
                response.Data = user;
            }
            catch (Exception ex)
            {
                response.ResponseMessage = "An error occurred while retrieving the user.";
                response.StatusCode = 500;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }


    }


}
