

using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace bezoni_shoes_store.Domain.Entities
{
    public class User : MongoIdentityUser<Guid>
    {
        public string? FullName { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public List<string>? OrderIDs { get; set; } = [];




    }
}
