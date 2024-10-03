using bezoni_shoes_store.Application.Product.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Product.Commands.AddProduct
{
    public record AddProductCommand (string Name, string Description, string Price, string Image) : IRequest<AddProductResult>;
}
