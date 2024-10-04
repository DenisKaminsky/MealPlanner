using System.Linq.Expressions;
using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Product;
using MealPlanner.Data.Interfaces.Repositories.Product;
using MealPlanner.Data.Models.Product;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MealPlanner.Data.Repositories.Product
{
    public class ProductRepository: BaseRepository, IProductRepository
    {
        private readonly IMongoCollection<ProductCategory> _productCategories;
        private readonly IMongoCollection<Models.Product.Product> _products;

        public ProductRepository(IMongoClient client, IMongoDatabase database, IMapper mapper) : base(client, database, mapper)
        {
            _productCategories = database.GetCollection<ProductCategory>(GetCollectionName<ProductCategory>());
            _products= database.GetCollection<Models.Product.Product>(GetCollectionName<Models.Product.Product>());
        }

        public async Task<List<ProductDTO>> GetByCategoryAsync(string categoryId)
        {
            var data = await _products.AsQueryable()
                .Where(x => x.CategoryId.Equals(categoryId.ToLower()))
                .Select(ToProductDTO)
                .ToListAsync();

            return data;
        }

        public async Task<List<ProductDTO>> SearchByNameAsync(string name)
        {
            var result = await _products.AsQueryable()
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .Select(ToProductDTO)
                .ToListAsync();

            return result;
        }


        private Expression<Func<Models.Product.Product, ProductDTO>> ToProductDTO = x => new ProductDTO
        {
            Id = x.Id,
            Name = x.Name,
            UnitOfMeasurement = x.UnitOfMeasurement
        };
    }
}
