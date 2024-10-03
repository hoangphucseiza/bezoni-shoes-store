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

    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userCollection;

        public UserRepository(UserManager<User> userCollecion)
        {
            _userCollection = userCollecion;
        }

        public async Task<IdentityResult> AddAdmin(User user, string password)
        {
            // create user
            var result = await _userCollection.CreateAsync(user, password);
            if (result.Succeeded)
            {
                // add user to role
                await _userCollection.AddToRoleAsync(user, "Admin");
            }
            return result;
        }

        public async Task<IdentityResult> AddUser(User user, string password)
        {
            // create user
            var result = await _userCollection.CreateAsync(user, password);
            if (result.Succeeded)
            {
                // add user to role
                await _userCollection.AddToRoleAsync(user, "User");
            }
            return result;
        }

        public async Task<bool> checkPassWord(User user ,string password)
        {
            // Kiểm tra xem mật khẩu có đúng hay không
            var result = await _userCollection.CheckPasswordAsync(user, password);
            return result; // Trả về true nếu mật khẩu đúng, ngược lại false
        }

        public async Task<string> GetRoleByUser(User user)
        {
            var roles = await _userCollection.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }

        public async Task<User> GetUserByEmail(string email)
        {
           var user = await _userCollection.FindByEmailAsync(email);
            return user;
        }

        public async Task<User> GetUserById(string id)
        {
          var user = await _userCollection.FindByIdAsync(id);
            return user;
        }
    }
}
