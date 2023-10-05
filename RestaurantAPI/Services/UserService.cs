using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entity;
using RestaurantAPI.Interfaces;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class UserService : IUserService
    {
        private readonly RestaurantDbContext _restaurantDb;
        private readonly IMapper _mapper;

        public UserService(RestaurantDbContext restaurantDb, IMapper mapper)
        {
            _restaurantDb = restaurantDb;
            _mapper = mapper;
        }

        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(int id)
        {
          var user =   await _restaurantDb.Users.FindAsync(id);
            if (user == null) return;

            _restaurantDb.Users.Remove(user);
          await  _restaurantDb.SaveChangesAsync();
            

        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var entity = await _restaurantDb.Users.OrderByDescending(x => x.Id).ToListAsync();
            return _mapper.Map<IEnumerable<User>>(entity);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var entity = await _restaurantDb.Users.FindAsync(id);
            return _mapper.Map<User>(entity);
        }

        public async Task UpdateUserAsync(int id, UserDTO user)
        {
            var entity = await _restaurantDb.Users.FindAsync(id);
            if (entity == null) return;
            var newUser = new UserDTO
            {
                Id = id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender,
                Email = entity.Email,
                PhoneNo = entity.PhoneNo,
                Address = entity.Address,
                DateOfBirth = entity.DateOfBirth,
                State = entity.State,
                Country = entity.Country,
                LastModifiedDate = DateTime.UtcNow,


            };

            

            _mapper.Map<UserDTO>(newUser);
            await _restaurantDb.SaveChangesAsync();
        }
        

    }
}
