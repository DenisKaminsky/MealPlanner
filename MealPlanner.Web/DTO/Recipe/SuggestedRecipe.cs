namespace MealPlanner.Web.DTO.Recipe
{
    public class SuggestedRecipe
    {
        public string Name { get; set; }

        public IEnumerable<string> PreparationSteps { get; set; }

        public IEnumerable<string> Ingredients { get; set; }

        public IEnumerable<string> Instructions { get; set; }

        public int CookTimeInMinutes { get; set; }
    }
}
