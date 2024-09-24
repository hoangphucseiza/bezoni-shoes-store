using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Services;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Infrastucture.Authentication
{
    public class JWTTokenGenerator : IJWTTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JWTTokenGenerator(IOptions<JwtSettings> jwtSettings, IDateTimeProvider dateTimeProvider)
        {
            _jwtSettings = jwtSettings.Value;
            _dateTimeProvider = dateTimeProvider;
        }
        public string GenerateToken(User user)
        {
            var signiningCredentials = new SigningCredentials(
                               new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                                              SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signiningCredentials
                );
            
            return new JwtSecurityTokenHandler().WriteToken(securityToken);

        }
    }
}
