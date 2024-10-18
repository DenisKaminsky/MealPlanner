using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Recipe;
using MealPlanner.Data.Interfaces.Repositories.Recipe;
using MealPlanner.Web.DTO.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers.Recipe
{
    public class MyRecipesController : BaseAPIController
    {
        private readonly IMyRecipeRepository _recipeRepository;

        public MyRecipesController(IMapper mapper, IMyRecipeRepository recipeRepository) : base(mapper)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _recipeRepository.GetAllAsync();

            var response = Mapper.Map<List<GetMyRecipeResponse>>(data);

            var sorted = response
                .OrderBy(x => x.Name)
                .ToList();

            return Ok(sorted);
        }

        [HttpGet("{recipeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string recipeId)
        {
            var data = await _recipeRepository.GetByIdAsync(recipeId);

            var response = Mapper.Map<GetMyRecipeResponse>(data);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("Save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SaveAsync(SaveNewRecipeRequest newRecipe)
        {
            var mappedData = Mapper.Map<SaveNewRecipeDTO>(newRecipe);

            var newId = await _recipeRepository.CreateAsync(mappedData);
            var response = new SaveNewRecipeResponse
            {
                NewId = newId
            };

            return CreatedAtAction(nameof(GetById), new { recipeId = newId }, response);
        }
    }
}
