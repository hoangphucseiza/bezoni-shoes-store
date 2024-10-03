
using bezoni_shoes_store.Application.Authentication.Common;
using MediatR;


namespace bezoni_shoes_store.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password ) : IRequest< AuthenticationResult>;

}
