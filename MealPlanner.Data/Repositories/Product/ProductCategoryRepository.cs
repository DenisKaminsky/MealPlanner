using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Product;
using MealPlanner.Data.Interfaces.Repositories.Product;
using MealPlanner.Data.Models.Product;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MealPlanner.Data.Repositories.Product
{
    public class ProductCategoryRepository: BaseRepository, IProductCategoryRepository
    {
        private readonly IMongoCollection<ProductCategory> _productCategories;

        public ProductCategoryRepository(IMongoClient client, IMongoDatabase database, IMapper mapper) : base(client, database, mapper)
        {
            _productCategories = database.GetCollection<ProductCategory>(GetCollectionName<ProductCategory>());
        }

        public async Task<List<ProductCategoryDTO>> GetAllAsync()
        {
            var items = await _productCategories
                .AsQueryable()
                .OrderBy(x => x.Name)
                .ToListAsync();

            return Mapper.Map<List<ProductCategoryDTO>>(items);
        }
    }
}
