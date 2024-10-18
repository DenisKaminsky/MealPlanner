using MealPlanner.Data.Attributes;

namespace MealPlanner.Data.Models.Recipe
{
    [BsonCollection("MyRecipe")]
    public class MyRecipe : BaseModel
    {
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public IEnumerable<string> PreparationSteps { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public IEnumerable<string> Instructions { get; set; }
        public int CookTimeInMinutes { get; set; }
    }
}
