using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.Product.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.Product.Commands.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, AddProductResult>
    {
        private readonly IProductRepository _productRepository;
 
        public Task<AddProductResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
