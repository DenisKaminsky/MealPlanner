namespace MealPlanner.Web.DTO.Product
{
    public class GetProductCategoryWithProductsResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<GetProductResponse> Products { get; set; }
    }
}
