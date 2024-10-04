using MealPlanner.Web.Interfaces.Services;
using OpenAI.Chat;

namespace MealPlanner.Web.Services
{
    public class MealSuggestionService: BaseService, IMealSuggestionService
    {
        public void SuggestMeal()
        {
            var apiKey = "key here";

            ChatClient client = new(model: "gpt-3.5-turbo", apiKey: apiKey);

            ChatCompletion chatCompletion = client.CompleteChat("What is .NET 8");

            var result = chatCompletion.Content;
        }
    }
}
