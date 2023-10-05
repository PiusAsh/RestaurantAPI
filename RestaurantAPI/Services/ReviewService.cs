using AutoMapper;
using RestaurantAPI.Entity;
using RestaurantAPI.Interfaces;

namespace RestaurantAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly RestaurantDbContext _restaurantDb;
        private readonly IMapper _mapper;

        public ReviewService(RestaurantDbContext restaurantDb, IMapper mapper)
        {
            _restaurantDb = restaurantDb;
            _mapper = mapper;
        }
    }
}
