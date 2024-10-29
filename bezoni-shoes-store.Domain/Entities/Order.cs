using MongoDB.Bson.Serialization.Attributes;

namespace bezoni_shoes_store.Domain.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public decimal TotalPrice { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? CustomerId { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public List<string> OrderDetailsID { get; set; } = new();
    }
}
