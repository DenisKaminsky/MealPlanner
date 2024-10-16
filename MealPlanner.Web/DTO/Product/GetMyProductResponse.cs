namespace MealPlanner.Web.DTO.Product
{
    public class GetMyProductResponse
    {
        public string Id { get; set; }

        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductUnitOfMeasurement { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public double Quantity { get; set; }
    }
}
