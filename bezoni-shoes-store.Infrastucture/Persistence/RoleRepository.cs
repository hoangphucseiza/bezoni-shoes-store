using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.MongoDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Infrastucture.Persistence
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<Role> _roleCollection;

        public RoleRepository(IOptions<MongoDBSettings> settings, RoleManager<Role> roleCollecion)
        {
            //var client = new MongoClient(settings.Value.ConnectionString);
            //var database = client.GetDatabase(settings.Value.DatabaseName);

            _roleCollection = roleCollecion;
        }
        public async Task AddRole(string name)
        {
            await _roleCollection.CreateAsync(new Role { Name = name.ToLower().Trim() });
        }

        public async Task<string> GetNameRoleByID(string id)
        {
            var role = await _roleCollection.FindByIdAsync(id);
            return role.Name;
        }

        public Task RemoveRole(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RoleExits(string name)
        {
            var role = await _roleCollection.FindByNameAsync(name.ToLower().Trim());
            if(role == null)
            {
                return false;
            }
            return true;
        }
    }
}
