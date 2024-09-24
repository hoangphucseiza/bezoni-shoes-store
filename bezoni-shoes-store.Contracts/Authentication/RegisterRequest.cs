using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Contracts.Authentication
{
    public record RegisterRequest(string Name, string Email, string Password);
    
}
