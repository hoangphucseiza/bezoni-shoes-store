using bezoni_shoes_store.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Commands.CreateAdminAccount
{
    public record CreateAdminAccountCommand(string Email, string UserName, string FullName, string Password) : IRequest<CreateAdminAccountResult>;
   
}
