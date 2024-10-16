namespace MealPlanner.Data.Interfaces.DTO.Product
{
    public class GetMyProductDTO: BaseDTO
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductUnitOfMeasurement { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public double Quantity { get; set; }
    }
}
