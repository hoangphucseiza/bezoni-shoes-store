using bezoni_shoes_store.Application.OrderCQRS.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.OrderCQRS.Command.AddCategory
{
    public record AddCategoryCommand(string Name) : IRequest<AddCategoryResult>;
}
