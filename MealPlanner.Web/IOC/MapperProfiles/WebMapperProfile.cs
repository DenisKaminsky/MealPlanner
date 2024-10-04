using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Product;
using MealPlanner.Web.DTO.Product;

namespace MealPlanner.Web.IOC.MapperProfiles
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<ProductDTO, ProductResponse>();
            CreateMap<ProductCategoryDTO, ProductCategoryResponse>();
            CreateMap<ProductCategoryWithProductsDTO, ProductCategoryWithProductsResponse>();
        }
    }
}
