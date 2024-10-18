using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Product;
using MealPlanner.Data.Interfaces.DTO.Recipe;
using MealPlanner.Data.Models.Product;
using MealPlanner.Data.Models.Recipe;

namespace MealPlanner.Data.IOC.MapperProfiles
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<ProductCategory, GetProductCategoryDTO>();

            CreateMap<MyRecipe, GetMyRecipeDTO>();
            CreateMap<SaveNewRecipeDTO, MyRecipe>();
        }
    }
}
