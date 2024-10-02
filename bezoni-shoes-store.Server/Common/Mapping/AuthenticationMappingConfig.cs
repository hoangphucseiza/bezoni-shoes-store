using bezoni_shoes_store.Application.Authentication.Commands.AddRole;
using bezoni_shoes_store.Application.Authentication.Commands.Register;
using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Authentication.Queries.Login;
using bezoni_shoes_store.Application.Authentication.Queries.RefreshToken;
using bezoni_shoes_store.Contracts.Authentication;
using Mapster;

namespace bezoni_shoes_store.Server.Common.Mapping
{
    public class AuthenticationMappingConfig
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AddRoleRequest, AddRoleCommand>();
            config.NewConfig<RefreshTokenRequest, RefreshTokenQuery>();


            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest.RefreshToken, src => src.RefreshToken)
                .Map(dest => dest.Id, src => src.user.Id.ToString())
                .Map(dest => dest.FullName, src => src.user.FullName)
                .Map(dest => dest.UserName, src => src.user.UserName.ToString())
                .Map(dest => dest.Email, src => src.user.Email.ToString());





        }
    }
}
