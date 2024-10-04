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
        private readonly IMongoCollection<Models.Product.Product> _products;

        public ProductCategoryRepository(IMongoClient client, IMongoDatabase database, IMapper mapper) : base(client, database, mapper)
        {
            _productCategories = database.GetCollection<ProductCategory>(GetCollectionName<ProductCategory>());
            _products = database.GetCollection<Models.Product.Product>(GetCollectionName<Models.Product.Product>());
        }

        public async Task<List<ProductCategoryDTO>> GetAllAsync()
        {
            var items = await _productCategories
                .AsQueryable()
                .OrderBy(x => x.Name)
                .ToListAsync();

            return Mapper.Map<List<ProductCategoryDTO>>(items);
        }

        public async Task<ProductCategoryWithProductsDTO> GetCategoryWithProductsAsync(string categoryId)
        {
            var item = await _productCategories
                .AsQueryable()
                .Where(x => x.Id == categoryId.ToLower())
                .GroupJoin(
                    _products,
                    category => category.Id,
                    product => product.CategoryId,
                    (category, products) => new ProductCategoryWithProductsDTO
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Products = products.Select(x => new ProductDTO
                        {
                            Id = x.Id,
                            Name = x.Name,
                            UnitOfMeasurement = x.UnitOfMeasurement
                        })
                    })
                .SingleOrDefaultAsync();

            return item;
        }
    }
}
