using MealPlanner.Data.Attributes;

namespace MealPlanner.Data.Models.Product
{
    [BsonCollection("ProductCategory")]
    public class ProductCategory: BaseModel
    {
        public string Name { get; set; }
    }
}
