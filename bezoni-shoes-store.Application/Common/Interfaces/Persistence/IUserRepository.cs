using bezoni_shoes_store.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);

        Task<bool> checkPassWord(User user,string password);
        Task<IdentityResult>  AddUser(User user, string password);

        Task<User> GetUserById(string id);
    }
}
