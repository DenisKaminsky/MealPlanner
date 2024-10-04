using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Product;
using MealPlanner.Data.Models.Product;

namespace MealPlanner.Data.IOC.MapperProfiles
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<ProductCategory, ProductCategoryDTO>();
        }
    }
}
