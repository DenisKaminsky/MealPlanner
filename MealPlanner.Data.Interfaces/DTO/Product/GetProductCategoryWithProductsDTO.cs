namespace MealPlanner.Data.Interfaces.DTO.Product
{
    public class GetProductCategoryWithProductsDTO: GetProductCategoryDTO
    {
        public IEnumerable<GetProductDTO> Products { get; set; }
    }
}
