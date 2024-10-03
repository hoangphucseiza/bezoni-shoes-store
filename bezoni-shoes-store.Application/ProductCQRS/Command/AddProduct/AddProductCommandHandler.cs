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
        private readonly ICategoryRepository _categoryRepository;

        public AddProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<AddProductResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
               Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Image = request.Image,
                CategoryID = request.CategoryID
            };

             await _productRepository.AddProduct(product);

            var KqProduct = await _productRepository.FindProductByName(request.Name);

            await _categoryRepository.AddProductIDToVCategory(request.CategoryID, KqProduct.Id);


            return new AddProductResult("Add Product Success");
        }
    }
}
