using MealPlanner.Data.Interfaces.DTO.Product;

namespace MealPlanner.Data.Interfaces.Repositories.Product
{
    public interface IProductCategoryRepository
    {
       Task<List<ProductCategoryDTO>> GetAllAsync();

       Task<ProductCategoryWithProductsDTO> GetCategoryWithProductsAsync(string categoryId);
    }
}
