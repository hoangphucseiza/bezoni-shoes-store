using bezoni_shoes_store.Application.Authentication.Common;
using bezoni_shoes_store.Application.Common.Errors;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Authentication.Commands.AddRole
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, AddRoleResult>
    {
        private readonly IRoleRepository _roleRepository;

        public AddRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<AddRoleResult> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            //check role exists
           var roleExists = await _roleRepository.RoleExits(request.Name);
            if (roleExists)
            {
                throw new RoleAlreadyExistsException();
            }

            await _roleRepository.AddRole(request.Name);

            return new AddRoleResult("Role added successfully");
        }
    }
}
