using MealPlanner.Data.Attributes;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MealPlanner.Data.Models.Product
{
    [BsonCollection("Product")]
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public string UnitOfMeasurement { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
    }
}
