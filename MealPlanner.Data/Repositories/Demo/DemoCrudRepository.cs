using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Demo;
using MealPlanner.Data.Interfaces.Repositories.Demo;
using MealPlanner.Data.Models.Demo;
using MongoDB.Driver;

namespace MealPlanner.Data.Repositories.Demo
{
    public class DemoCrudRepository : BaseRepository<DemoTest, DemoTestDTO>, IDemoCrudRepository
    {
        public DemoCrudRepository(IMongoClient client, IMongoDatabase database, IMapper mapper) : base(client, database, mapper) { }
    }
}
