using AspNetCore.Identity.MongoDbCore.Models;
using bezoni_shoes_store.Application.Common.Errors;
using bezoni_shoes_store.Application.Common.Errors.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Authentication;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.Common.Interfaces.Services;
using bezoni_shoes_store.Domain.Entities;
using bezoni_shoes_store.Infrastucture.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
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

        public string GenerateRefreshToken(User user)
        {

            var signiningCredentials = new SigningCredentials(
                                         new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                                            SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
             issuer: _jwtSettings.Issuer,
              audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddDays(30),
                claims: claims,
               signingCredentials: signiningCredentials
                                                                                                          );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public string GenerateToken(User user)
        {
            var signiningCredentials = new SigningCredentials(
                               new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                                              SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.FullName),
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

        public string GetIDByRefreshToken(string refreshToken)
        {
            //1. Validate the token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret))
            };

            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out securityToken);

            //2. Check the token is valid

            var jwtToken = securityToken as JwtSecurityToken;
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new InvalidToken();
            }

            //3. Check token còn hạn sử dụng không
            var utcNow = _dateTimeProvider.UtcNow;
            var expiryDateUnix = long.Parse(principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if (expiryDateTimeUtc < utcNow)
            {
                throw new Exception("This token has expired");
            }

            //4. Get user ID from token
            //var userId = jwtToken.Claims[0].Value;
            // get userID from claims subs
            var userId = jwtToken.Claims.Single(x => x.Type == "sub").Value;


            return userId;


        }
    }
}
