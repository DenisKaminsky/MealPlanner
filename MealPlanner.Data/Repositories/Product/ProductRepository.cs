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

        public async Task<List<GetProductDTO>> GetByCategoryAsync(string categoryId)
        {
            var data = await _products.AsQueryable()
                .Where(x => x.CategoryId.Equals(categoryId.ToLower()))
                .Select(ToProductDTO)
                .ToListAsync();

            return data;
        }

        public async Task<List<GetProductDTO>> SearchByNameAsync(string name)
        {
            var result = await _products.AsQueryable()
                .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .Select(ToProductDTO)
                .ToListAsync();

            return result;
        }

        public async Task<List<GetProductWithCategoryDTO>> GetAllAsync()
        {
            var items = await _products
                .AsQueryable()
                .Join(
                    _productCategories,
                    product => product.CategoryId,
                    category => category.Id,
                    (product, category) => new GetProductWithCategoryDTO
                    {
                        Id = product.Id,
                        Name = product.Name,
                        UnitOfMeasurement = product.UnitOfMeasurement,
                        CategoryId = category.Id,
                        CategoryName = category.Name
                    })
                .ToListAsync();

            return items;
        }


        private readonly Expression<Func<Models.Product.Product, GetProductDTO>> ToProductDTO = x => new GetProductDTO
        {
            Id = x.Id,
            Name = x.Name,
            UnitOfMeasurement = x.UnitOfMeasurement
        };
    }
}
