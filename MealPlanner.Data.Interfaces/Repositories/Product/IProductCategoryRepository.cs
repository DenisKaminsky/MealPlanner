using MealPlanner.Data.Interfaces.DTO.Product;

namespace MealPlanner.Data.Interfaces.Repositories.Product
{
    public interface IProductCategoryRepository
    {
       Task<List<GetProductCategoryDTO>> GetAllAsync();

       Task<GetProductCategoryWithProductsDTO> GetCategoryWithProductsAsync(string categoryId);
    }
}
