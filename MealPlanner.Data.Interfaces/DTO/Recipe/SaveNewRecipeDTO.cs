namespace MealPlanner.Data.Interfaces.DTO.Recipe
{
    public class SaveNewRecipeDTO : BaseCreateDTO
    {
        public string Name { get; set; }
        public IEnumerable<string> PreparationSteps { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public IEnumerable<string> Instructions { get; set; }
        public int CookTimeInMinutes { get; set; }
        public DateTime CreatedDateUtc { get; set; }
    }
}
