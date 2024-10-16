namespace MealPlanner.Data.Interfaces.DTO.Product
{
    public class GetProductDTO: BaseDTO
    {
        public string Name { get; set; }

        public string UnitOfMeasurement { get; set; }
    }
}
