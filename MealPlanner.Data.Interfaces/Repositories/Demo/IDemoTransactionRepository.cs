using MealPlanner.Data.Interfaces.DTO.Demo;

namespace MealPlanner.Data.Interfaces.Repositories.Demo
{
    public interface IDemoTransactionRepository
    {
        Task<DemoTestDTO> GetFirstByTitleAsync(string title);
    }
}
