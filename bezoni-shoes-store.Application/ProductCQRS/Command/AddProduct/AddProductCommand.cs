using bezoni_shoes_store.Application.ProductCQRS.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Command.AddProduct
{
    public record AddProductCommand(string Name, string Description, decimal Price, string Image, string CategoryID) : IRequest<AddProductResult>;

}
