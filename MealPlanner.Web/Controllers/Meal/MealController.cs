using AutoMapper;
using MealPlanner.Web.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers.Meal
{
    public class MealController : BaseAPIController
    {
        private readonly IMealSuggestionService _mealSuggestionService;

        public MealController(IMapper mapper, IMealSuggestionService mealSuggestionService) : base(mapper)
        {
            _mealSuggestionService = mealSuggestionService;
        }
        
        [HttpGet("Suggest")]
        public async Task<IActionResult> Get()
        {
            _mealSuggestionService.SuggestMeal();

            return Ok();
        }
    }
}
