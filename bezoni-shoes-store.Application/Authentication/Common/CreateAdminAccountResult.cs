﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Common
{
    public record CreateAdminAccountResult   ( string Id,
        string FullName,
        string UserName,
        string Email,
        string Token,
        string RefreshToken
        );
}