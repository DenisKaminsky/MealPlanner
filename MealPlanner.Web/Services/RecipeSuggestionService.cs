using MealPlanner.Web.DTO.Recipe;
using MealPlanner.Web.Interfaces.Services;
using OpenAI.Chat;

namespace MealPlanner.Web.Services
{
    public class RecipeSuggestionService: BaseService, IRecipeSuggestionService
    {

        public async Task<IEnumerable<SuggestedRecipe>> SuggestRecipesAsync(int numberOfRecipes)
        {
            await Task.Delay(3000);

            /*var apiKey = "key here";

            ChatClient client = new(model: "gpt-3.5-turbo", apiKey: apiKey);

            ChatCompletion chatCompletion = client.CompleteChat("What is .NET 8");

            var result = chatCompletion.Content;*/

            return Array.Empty<SuggestedRecipe>();
        }
    }
}
