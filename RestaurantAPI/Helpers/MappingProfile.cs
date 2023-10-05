using RestaurantAPI.Entity;
using RestaurantAPI.Models;

namespace RestaurantAPI.Helpers
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();

            CreateMap<ReviewsDTO, Review>();
            CreateMap<Review, ReviewsDTO>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();


            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();





        }
    }
}
