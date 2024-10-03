using MealPlanner.Data.Interfaces.DTO;

namespace MealPlanner.Data.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseDTO
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(string id);
    }
}
