namespace MealPlanner.Data.Interfaces.DTO.Recipe
{
    public class GetMyRecipeDTO : BaseDTO
    {
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public IEnumerable<string> PreparationSteps { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
        public IEnumerable<string> Instructions { get; set; }
        public int CookTimeInMinutes { get; set; }
        public DateTime CreatedDateUtc { get; set; }
    }
}
