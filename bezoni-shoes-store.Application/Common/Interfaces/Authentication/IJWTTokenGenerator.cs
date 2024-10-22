using bezoni_shoes_store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Interfaces.Authentication
{
    public interface IJWTTokenGenerator
    {
        string GenerateToken(User user, string role);

        string GenerateRefreshToken(User user);

        string GetIDByToken(string Token);

        Task<string> CheckAccessToken(string accessToken);
    }
}
