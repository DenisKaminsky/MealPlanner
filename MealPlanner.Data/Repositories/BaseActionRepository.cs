using AutoMapper;
using MealPlanner.Data.Interfaces.DTO;
using MealPlanner.Data.Interfaces.Repositories;
using MealPlanner.Data.Models;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MealPlanner.Data.Repositories
{
    public abstract class BaseActionRepository<TModel, TDTO> : BaseRepository, IBaseActionRepository<TDTO> 
        where TModel : BaseModel 
        where TDTO : BaseDTO
    {
        protected static readonly FilterDefinition<TModel> EmptyFiler = Builders<TModel>.Filter.Empty;

        protected readonly IMongoCollection<TModel> Collection;

        protected BaseActionRepository(IMongoClient client, IMongoDatabase database, IMapper mapper) : base(client, database, mapper)
        {
            Collection = database.GetCollection<TModel>(GetCollectionName<TModel>());
        }

        #region Read
        
        public virtual async Task<List<TDTO>> GetAllAsync()
        {
            var items = await (await Collection.FindAsync(EmptyFiler)).ToListAsync();

            return Mapper.Map<List<TDTO>>(items);
        }

        public virtual async Task<TDTO> GetByIdAsync(string id)
        {
            var filter = Builders<TModel>.Filter.Eq(doc => doc.Id, id);

            var item = await (await Collection.FindAsync(filter)).SingleOrDefaultAsync();

            return Mapper.Map<TDTO>(item);
        }

        public virtual async Task<List<TDTO>> GetAsync(Expression<Func<TDTO, bool>> filterExpression)
        {
            var modelExpression = Mapper.Map<Expression<Func<TModel, bool>>>(filterExpression);

            var items = await (await Collection.FindAsync(modelExpression)).ToListAsync();

            return Mapper.Map<List<TDTO>>(items);
        }

        public virtual async Task<TDTO> GetFirstAsync(Expression<Func<TDTO, bool>> filterExpression)
        {
            var modelExpression = Mapper.Map<Expression<Func<TModel, bool>>>(filterExpression);

            var item =  await (await Collection.FindAsync(modelExpression)).FirstOrDefaultAsync();

            return Mapper.Map<TDTO>(item);
        }

        #endregion

        #region Create

        public virtual async Task<string> CreateAsync(TDTO item)
        {
            var model = Mapper.Map<TModel>(item);

            await Collection.InsertOneAsync(model);

            return model.Id;
        }

        protected virtual async Task CreateAsync(TDTO item, IClientSessionHandle clientSessionHandle)
        {
            var model = Mapper.Map<TModel>(item);

            await Collection.InsertOneAsync(clientSessionHandle, model);
        }

        protected virtual async Task CreateManyAsync(IEnumerable<TDTO> items, IClientSessionHandle clientSessionHandle)
        {
            var models = Mapper.Map<List<TModel>>(items);

            await Collection.InsertManyAsync(clientSessionHandle, models);
        }

        public virtual async Task CreateManyAsync(IEnumerable<TDTO> items)
        {
            var models = Mapper.Map<List<TModel>>(items);

            await Collection.InsertManyAsync(models);
        }

        #endregion

        #region Replace

        protected virtual async Task<bool> ReplaceAsync(TDTO item, IClientSessionHandle clientSessionHandle)
        {
            var filter = Builders<TModel>.Filter.Eq(doc => doc.Id, item.Id);
            var model = Mapper.Map<TModel>(item);

            var updateResult = await Collection.ReplaceOneAsync(clientSessionHandle, filter, model, options: new ReplaceOptions());

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public virtual async Task<bool> ReplaceAsync(TDTO item)
        {
            var filter = Builders<TModel>.Filter.Eq(doc => doc.Id, item.Id);
            var model = Mapper.Map<TModel>(item);

            var updateResult = await Collection.ReplaceOneAsync(filter, model, options: new ReplaceOptions());

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        #endregion

        #region Delete

        protected virtual async Task<bool> DeleteOneAsync(string id, IClientSessionHandle clientSessionHandle)
        {
            var filter = Builders<TModel>.Filter.Eq(doc => doc.Id, id);

            var deleteResult = await Collection.DeleteOneAsync(clientSessionHandle, filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public virtual async Task<bool> DeleteOneAsync(string id)
        {
            var filter = Builders<TModel>.Filter.Eq(doc => doc.Id, id);

            var deleteResult = await Collection.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        protected virtual async Task<bool> DeleteManyAsync(Expression<Func<TDTO, bool>> filterExpression, IClientSessionHandle clientSessionHandle)
        {
            var modelExpression = Mapper.Map<Expression<Func<TModel, bool>>>(filterExpression);

            var deleteResult = await Collection.DeleteManyAsync(clientSessionHandle, modelExpression);
            
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public virtual async Task<bool> DeleteManyAsync(Expression<Func<TDTO, bool>> filterExpression)
        {
            var modelExpression = Mapper.Map<Expression<Func<TModel, bool>>>(filterExpression);

            var deleteResult = await Collection.DeleteManyAsync(modelExpression);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        #endregion
    }
}
