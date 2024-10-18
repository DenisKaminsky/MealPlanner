using MealPlanner.Web.DTO.Recipe;

namespace MealPlanner.Web.Interfaces.Services
{
    public interface IRecipeSuggestionService
    {
        Task<IEnumerable<SuggestedRecipe>> SuggestRecipesAsync(int numberOfRecipes);
    }
}
