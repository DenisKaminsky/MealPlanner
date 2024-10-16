using MealPlanner.Data.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MealPlanner.Data.Models.Product
{
    [BsonCollection("MyProduct")]
    public class MyProduct : BaseModel
    {
        public double Quantity { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
    }
}
