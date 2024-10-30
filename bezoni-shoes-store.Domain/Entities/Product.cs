using MongoDB.Bson.Serialization.Attributes;

namespace bezoni_shoes_store.Domain.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }

        public int? Voucher { get; set; }
        public string? Description { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? CategoryID { get; set; }
    }
}
