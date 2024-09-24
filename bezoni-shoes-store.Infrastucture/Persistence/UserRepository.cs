using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.MongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Infrastucture.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _userCollection = database.GetCollection<User>(settings.Value.UserCollectionName);
        }
        public async Task AddUser(User user)
        {
             await _userCollection.InsertOneAsync(user);
        }

        public async Task<User?> GetUserByEmail(string email)
        {

           return  await _userCollection.Find(u => u.Email == email).FirstOrDefaultAsync();

        }
    }
}
