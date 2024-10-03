﻿

using bezoni_shoes_store.Domain.Entities;

namespace bezoni_shoes_store.Application.Authentication.Common
{
    public record AuthenticationResult(string Id,
        string FullName,
        string UserName,
        string Email,
        string Token,
        string RefreshToken
        );
}
