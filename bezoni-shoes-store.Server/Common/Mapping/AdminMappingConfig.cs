using bezoni_shoes_store.Application.Authentication.Commands.Register;
using bezoni_shoes_store.Application.Authentication.Queries.Login;
using bezoni_shoes_store.Application.Authentication.Queries.RefreshToken;
using bezoni_shoes_store.Contracts.Authentication;
using Mapster;

namespace bezoni_shoes_store.Server.Common.Mapping
{
    public class AdminMappingConfig
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<RegisterRequest, RegisterCommand>();
        }
    }
}
