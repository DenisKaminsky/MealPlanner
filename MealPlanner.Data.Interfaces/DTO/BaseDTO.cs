namespace MealPlanner.Data.Interfaces.DTO
{
    public class BaseDTO
    {
        public string Id { get; }

        public BaseDTO(string id)
        {
            Id = id;
        }
    }
}
