

namespace bezoni_shoes_store.Contracts.Authentication
{
    public record AuthenticationResponse(
        string Id,
        string FullName,
        string UserName,
        string Email,
        string Token,
        string RefreshToken
        );
    
}
