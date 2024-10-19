using DotnetGeminiSDK.Client.Interfaces;
using MealPlanner.Data.Interfaces.Repositories.Product;
using MealPlanner.Web.DTO.Recipe;
using MealPlanner.Web.Interfaces.Services;
using Newtonsoft.Json;

namespace MealPlanner.Web.Services
{
    public class RecipeSuggestionService: BaseService, IRecipeSuggestionService
    {
        private readonly IMyProductRepository _myProductRepository;
        private readonly IGeminiClient _geminiClient;

        private static readonly Random Random = new Random();
        private static string _template = JsonConvert.SerializeObject(new[] {
            new SuggestedRecipe
            {
                Name = "Recipe name",
                PreparationSteps = new [] {
                    "Step1",
                    "Step2"
                },
                Ingredients = new [] {
                    "Ingredient1",
                    "Ingredient2"
                },
                Instructions = new [] {
                    "Instruction1",
                    "Instruction2"
                },
                CookTimeInMinutes = 20
            }
        });

        public RecipeSuggestionService(IMyProductRepository myProductRepository, IGeminiClient geminiClient)
        {
            _myProductRepository = myProductRepository;
            _geminiClient = geminiClient;
        }

        public async Task<IEnumerable<SuggestedRecipe>> SuggestRecipesAsync(int numberOfRecipes)
        {
            var myProducts = (await _myProductRepository.GetAllAsync())
                .Where(x => x.Quantity > 0)
                .Select(x => (x.ProductName, Random.Next()))
                .OrderBy(tuple => tuple.Item2)
                .Select(tuple => tuple.Item1)
                .ToArray();

            var myProductsParameter = string.Join(", ", myProducts);

            var prompt = $@"
                You are a recipe generator. Based on the ingredients provided, generate {numberOfRecipes} different recipes using this JSON schema:
                Recipe = {_template}
                Return: Array<Recipe>
                
                Where
                    - '{nameof(SuggestedRecipe.Ingredients)}' — string with ingredients.
                    - '{nameof(SuggestedRecipe.PreparationSteps)}' — string with steps to take before cooking begins.
                    - '{nameof(SuggestedRecipe.Instructions)}' — string with actual instructions for cooking the dish.
                    - '{nameof(SuggestedRecipe.CookTimeInMinutes)}' — approximate total cooking time (with preparation) in minutes.                

                Ingredients provided: {myProductsParameter}.
                Output should only contain JSON. Make Sure the JSON is valid. Don't include '```json' to the response.
            ";

            var response = await _geminiClient.TextPrompt(prompt);
            if (response?.Candidates.Any() ?? false)
            {
                var candidate = response.Candidates.First();
                if (candidate.Content.Parts.Any())
                {
                    var part = candidate.Content.Parts.First();
                    var result = JsonConvert.DeserializeObject<SuggestedRecipe[]>(part.Text)!;

                    return result;
                }
            }
            
            return Array.Empty<SuggestedRecipe>();
        }
    }
}
