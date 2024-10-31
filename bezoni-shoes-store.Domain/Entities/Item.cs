using MongoDB.Bson.Serialization.Attributes;

namespace bezoni_shoes_store.Domain.Entities
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Type { get; set; }
        public int? Quantity { get; set; }
        public string? ProductID { get; set; }
    }
}
