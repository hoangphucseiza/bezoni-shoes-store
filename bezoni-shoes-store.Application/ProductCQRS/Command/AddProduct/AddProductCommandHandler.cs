using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.ProductCQRS.Common;
using bezoni_shoes_store.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.ProductCQRS.Command.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, AddProductResult>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<AddProductResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
               Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Image = request.Image
            };

            await _productRepository.AddProduct(product);

            return new AddProductResult("Add Product Success");
        }
    }
}
