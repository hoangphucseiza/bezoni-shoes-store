

using bezoni_shoes_store.Domain.Entities;

namespace bezoni_shoes_store.Application.Authentication.Common
{
    public record AuthenticationResult(User user, string Token, string RefreshToken);
}
