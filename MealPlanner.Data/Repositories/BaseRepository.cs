using AutoMapper;
using MealPlanner.Data.Interfaces.DTO;
using MealPlanner.Data.Interfaces.Repositories;
using MealPlanner.Data.Models;
using MongoDB.Driver;

namespace MealPlanner.Data.Repositories
{
    public abstract class BaseRepository<TModel, TDTO> : BaseTransactionRepository, IBaseRepository<TDTO> 
        where TModel : BaseModel 
        where TDTO : BaseDTO
    {
        private static readonly FilterDefinition<TModel> EmptyFiler = Builders<TModel>.Filter.Empty;

        protected readonly IMongoCollection<TModel> Collection;

        protected BaseRepository(IMongoClient client, IMongoDatabase database, IMapper mapper) : base(client, database, mapper)
        {
            Collection = database.GetCollection<TModel>(GetCollectionName<TModel>());
        }

        public async Task<List<TDTO>> GetAllAsync()
        {
            var data = await Collection
                .Find(EmptyFiler)
                .ToListAsync();

            return Mapper.Map<List<TDTO>>(data);
        }

        public async Task<TDTO> GetByIdAsync(string id)
        {
            var item = await Collection.Find(x => x.Id == id).SingleOrDefaultAsync();

            return Mapper.Map<TDTO>(item);
        }
    }
}
