using AutoMapper;
using MealPlanner.Data.Attributes;
using MealPlanner.Data.Models;
using MongoDB.Driver;

namespace MealPlanner.Data.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IMongoClient _client;

        protected readonly IMongoDatabase Database;

        protected readonly IMapper Mapper;

        protected BaseRepository(IMongoClient client, IMongoDatabase database, IMapper mapper)
        {
            _client = client;
            Database = database;
            Mapper = mapper;
        }

        protected string GetCollectionName<T>() where T : BaseModel
        {
            var itemType = typeof(T);
            var attribute = itemType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault();
            if (attribute != null)
            {
                return ((BsonCollectionAttribute)attribute).CollectionName;
            }

            return itemType.Name;
        }

        protected Task<IClientSessionHandle> BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _client.StartSessionAsync(null, cancellationToken);
        }

        protected Task CommitTransactionAsync(IClientSessionHandle session, CancellationToken cancellationToken = default(CancellationToken))
        {
            return session.CommitTransactionAsync(cancellationToken);
        }

        protected Task RollbackTransactionAsync(IClientSessionHandle session, CancellationToken cancellationToken = default(CancellationToken))
        {
            return session.AbortTransactionAsync(cancellationToken);
        }
    }
}
