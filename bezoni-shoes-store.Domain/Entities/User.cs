

using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace bezoni_shoes_store.Domain.Entities
{
    public class User : MongoIdentityUser<Guid>
    {
        public string? FullName { get; set; }
        
        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string Avatar { get; set; } = "https://static.vecteezy.com/system/resources/previews/026/619/142/non_2x/default-avatar-profile-icon-of-social-media-user-photo-image-vector.jpg";

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public List<string>? VouncherIDs { get; set; } 
    }
}
