using MealPlanner.Data.Interfaces.DTO.Product;

namespace MealPlanner.Data.Interfaces.Repositories.Product
{
    public interface IMyProductRepository
    {
        Task<List<GetMyProductDTO>> GetAllAsync();

        Task SaveAsync(List<SaveMyProductDTO> myProducts);
    }
}
