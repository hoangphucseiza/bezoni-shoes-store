﻿using Amazon.Runtime.Internal;
using bezoni_shoes_store.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Commands.Register
{
    public record RegisterCommand(string Name, string Email, string Password) : IRequest<AuthenticationResult>;

}