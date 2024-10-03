using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Demo;
using MealPlanner.Data.Models.Demo;

namespace MealPlanner.Data.IOC.MapperProfiles
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            CreateMap<DemoTest, DemoTestDTO>().ReverseMap();
        }
    }
}
