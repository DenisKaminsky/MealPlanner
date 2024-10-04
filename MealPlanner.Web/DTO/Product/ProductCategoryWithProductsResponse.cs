namespace MealPlanner.Web.DTO.Product
{
    public class ProductCategoryWithProductsResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductResponse> Products { get; set; }
    }
}
