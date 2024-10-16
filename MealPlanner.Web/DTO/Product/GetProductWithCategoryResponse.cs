namespace MealPlanner.Web.DTO.Product
{
    public class GetProductWithCategoryResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string UnitOfMeasurement { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
