using MealPlanner.Data.Interfaces.DTO.Product;

namespace MealPlanner.Data.Interfaces.Repositories.Product
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetByCategoryAsync(string categoryId);

        Task<List<ProductDTO>> SearchByNameAsync(string name);

        Task<List<ProductWithCategoryDTO>> GetAllAsync();
    }
}
