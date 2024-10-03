﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Common.Interfaces.Persistence
{
    public interface IRoleRepository
    {
        Task AddRole(string name);

        Task RemoveRole(string name);

        Task<bool> RoleExits(string name);

        Task<string> GetNameRoleByID(string id);
    }
}
