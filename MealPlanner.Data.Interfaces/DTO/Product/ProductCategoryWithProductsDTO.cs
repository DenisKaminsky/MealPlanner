namespace MealPlanner.Data.Interfaces.DTO.Product
{
    public class ProductCategoryWithProductsDTO: ProductCategoryDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
