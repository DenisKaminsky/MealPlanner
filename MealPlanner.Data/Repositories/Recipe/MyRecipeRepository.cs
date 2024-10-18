using MealPlanner.Data.Interfaces.Repositories.Recipe;
using AutoMapper;
using MealPlanner.Data.Interfaces.DTO.Recipe;
using MongoDB.Driver;

namespace MealPlanner.Data.Repositories.Recipe
{
    public class MyRecipeRepository : BaseActionRepository<Models.Recipe.MyRecipe, GetMyRecipeDTO, SaveNewRecipeDTO>, IMyRecipeRepository
    {
        public MyRecipeRepository(IMongoClient client, IMongoDatabase database, IMapper mapper) : base(client, database, mapper)
        {
        }
    }
}
