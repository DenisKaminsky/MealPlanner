namespace MealPlanner.Data.Interfaces.DTO.Demo
{
    public class DemoTestDTO : BaseDTO
    {
        string Title { get; }

        double Price { get; }

        public DemoTestDTO(string id, string title, double price) : base(id)
        {
            Title = title;
            Price = price;
        }
    }
}
