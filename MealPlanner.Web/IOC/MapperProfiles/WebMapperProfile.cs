using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Product;
using MealPlanner.Web.DTO.Product;

namespace MealPlanner.Web.IOC.MapperProfiles
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<GetProductDTO, GetProductResponse>();
            CreateMap<GetMyProductDTO, GetMyProductResponse>();
            CreateMap<GetProductCategoryDTO, GetProductCategoryResponse>();
            CreateMap<GetProductCategoryWithProductsDTO, GetProductCategoryWithProductsResponse>();
            CreateMap<GetProductWithCategoryDTO, GetProductWithCategoryResponse>();

            CreateMap<SaveMyProductRequest, SaveMyProductDTO>();
        }
    }
}
