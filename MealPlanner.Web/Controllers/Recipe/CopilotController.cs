using AutoMapper;
using MealPlanner.Web.DTO.Recipe;
using MealPlanner.Web.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers.Recipe
{
    public class CopilotController : BaseAPIController
    {
        private readonly IRecipeSuggestionService _suggestionService;

        public CopilotController(IMapper mapper, IRecipeSuggestionService suggestionService) : base(mapper)
        {
            _suggestionService = suggestionService;
        }

        [HttpPost("Suggest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Suggest(SuggestRecipesRequest request)
        {
            var recipes = await _suggestionService.SuggestRecipesAsync(request.NumberOfRecipes);

            return Ok(recipes);
        }
    }
}
