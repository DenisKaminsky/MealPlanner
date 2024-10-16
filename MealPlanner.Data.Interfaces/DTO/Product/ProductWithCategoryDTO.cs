namespace MealPlanner.Data.Interfaces.DTO.Product
{
    public class ProductWithCategoryDTO : BaseDTO
    {
        public string Name { get; set; }

        public string UnitOfMeasurement { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
