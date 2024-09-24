

using MongoDB.Bson.Serialization.Attributes;

namespace bezoni_shoes_store.Domain.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
