using MealPlanner.Data.Interfaces.DTO.Recipe;

namespace MealPlanner.Data.Interfaces.Repositories.Recipe
{
    public interface IMyRecipeRepository
    {

        Task<List<GetMyRecipeDTO>> GetAllAsync();

        Task<GetMyRecipeDTO> GetByIdAsync(string id);
        
        Task<string> CreateAsync(SaveNewRecipeDTO item);

        Task<bool> DeleteOneAsync(string id);

        Task MarkAsFavorite(string id);

        Task Unfavorite(string id);
    }
}
