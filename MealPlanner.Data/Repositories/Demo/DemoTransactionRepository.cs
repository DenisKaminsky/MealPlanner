using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Demo;
using MealPlanner.Data.Interfaces.Repositories.Demo;
using MealPlanner.Data.Models.Demo;
using MongoDB.Driver;

namespace MealPlanner.Data.Repositories.Demo
{
    public class DemoTransactionRepository : BaseTransactionRepository, IDemoTransactionRepository
    {
        public DemoTransactionRepository(IMongoClient client, IMongoDatabase database, IMapper mapper) : base(client, database, mapper) { }

        public async Task<DemoTestDTO> GetFirstByTitleAsync(string title)
        {
            var collection = base.Database.GetCollection<DemoTest>(GetCollectionName<DemoTest>());

            var item = await collection.Find(x => x.Title == title).SingleOrDefaultAsync();

            return Mapper.Map<DemoTestDTO>(item);
        }
    }
}
