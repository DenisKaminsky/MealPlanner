using MealPlanner.Misc.Attributes;

namespace MealPlanner.Data.Models.Demo
{
    [BsonCollection("DemoTest")]
    public class DemoTest : BaseModel
    {
        public string Title { get; set; }

        public double Price { get; set; }
    }
}
