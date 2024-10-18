namespace MealPlanner.Data.Interfaces.DTO.Product
{
    public class SaveMyProductDTO : BaseCreateDTO
    {
        public string ProductId { get; set; }

        public double Quantity { get; set; }
    }
}
