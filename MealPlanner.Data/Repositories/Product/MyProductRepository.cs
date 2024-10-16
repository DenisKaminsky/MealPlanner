using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Product;
using MealPlanner.Data.Interfaces.Repositories.Product;
using MealPlanner.Data.Models.Product;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Transactions;


namespace MealPlanner.Data.Repositories.Product
{
    public class MyProductRepository : BaseRepository, IMyProductRepository
    {
        private readonly IMongoCollection<MyProduct> _myProducts;
        private readonly IMongoCollection<ProductCategory> _productCategories;
        private readonly IMongoCollection<Models.Product.Product> _products;

        public MyProductRepository(IMongoClient client, IMongoDatabase database, IMapper mapper) : base(client, database, mapper)
        {
            _myProducts = database.GetCollection<MyProduct>(GetCollectionName<MyProduct>());
            _products = database.GetCollection<Models.Product.Product>(GetCollectionName<Models.Product.Product>());
            _productCategories = database.GetCollection<ProductCategory>(GetCollectionName<ProductCategory>());
        }

        public async Task<List<GetMyProductDTO>> GetAllAsync()
        {
            var items = await _myProducts
                .AsQueryable()
                .Join(
                    _products,
                    myProduct => myProduct.ProductId,
                    product => product.Id,
                    (myProduct, product) => new
                    {
                        Id = myProduct.Id,
                        Quantity = myProduct.Quantity,
                        Product = product
                    })
                .Join(
                    _productCategories,
                    combined => combined.Product.CategoryId,
                    category => category.Id,
                    (combined, category) => new GetMyProductDTO
                    {
                        Id = combined.Id,
                        ProductId = combined.Product.Id,
                        ProductName = combined.Product.Name,
                        CategoryName = category.Name,
                        ProductUnitOfMeasurement = combined.Product.UnitOfMeasurement,
                        CategoryId = combined.Product.CategoryId,
                        Quantity = combined.Quantity,
                    })
                .ToListAsync();

            return items;
        }

        public async Task SaveAsync(List<SaveMyProductDTO> myProducts)
        {
            var currentProductIds = myProducts.Select(x => x.ProductId).ToArray();

            var listWrites = new List<WriteModel<MyProduct>>();

            //Delete old products
            var deleteFilter = Builders<MyProduct>.Filter.Nin(x => x.ProductId, currentProductIds);
            listWrites.Add(new DeleteManyModel<MyProduct>(deleteFilter));

            //Upsert current products
            foreach (var item in myProducts)
            {
                var filterDefinition = Builders<MyProduct>.Filter.Eq(p => p.ProductId, item.ProductId);
                var updateDefinition = Builders<MyProduct>.Update.Set(p => p.Quantity, item.Quantity);

                listWrites.Add(new UpdateOneModel<MyProduct>(filterDefinition, updateDefinition) { IsUpsert = true });
            }

            await _myProducts.BulkWriteAsync(listWrites);
        }
    }
}
