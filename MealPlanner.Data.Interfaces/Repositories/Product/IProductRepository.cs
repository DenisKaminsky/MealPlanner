using MealPlanner.Data.Interfaces.DTO.Product;

namespace MealPlanner.Data.Interfaces.Repositories.Product
{
    public interface IProductRepository
    {
        Task<List<GetProductDTO>> GetByCategoryAsync(string categoryId);

        Task<List<GetProductDTO>> SearchByNameAsync(string name);

        Task<List<GetProductWithCategoryDTO>> GetAllAsync();
    }
}
