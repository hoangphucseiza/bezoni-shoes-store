using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Contracts.Authentication
{
    public record AuthenticationResponse(
        string Id,
        string Name,
        string Email,
        string Token
        );
    
}
