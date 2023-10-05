using AutoMapper;
using RestaurantAPI.Entity;
using RestaurantAPI.Interfaces;

namespace RestaurantAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly RestaurantDbContext _restaurantDb;
        private readonly IMapper _mapper;

        public OrderService(RestaurantDbContext restaurantDb, IMapper mapper)
        {
            _restaurantDb = restaurantDb;
            _mapper = mapper;
        }
    }
}
