using bezoni_shoes_store.Application.Authentication.Commands.Register;
using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Authentication.Queries.Login;
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
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                //.Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);


        }
    }
}
