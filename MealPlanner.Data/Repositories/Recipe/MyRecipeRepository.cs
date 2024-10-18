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

        public async Task MarkAsFavorite(string id)
        {
            var filter = Builders<Models.Recipe.MyRecipe>.Filter.Eq(x => x.Id, id);

            var update = Builders<Models.Recipe.MyRecipe>.Update
                .Set(x => x.IsFavorite, true);

            await Collection.UpdateOneAsync(filter, update);
        }

        public async Task Unfavorite(string id)
        {
            var filter = Builders<Models.Recipe.MyRecipe>.Filter.Eq(x => x.Id, id);

            var update = Builders<Models.Recipe.MyRecipe>.Update
                .Set(x => x.IsFavorite, false);

            await Collection.UpdateOneAsync(filter, update);
        }
    }
}
