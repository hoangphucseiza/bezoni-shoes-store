using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Application.OrderCQRS.Common;
using bezoni_shoes_store.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezoni_shoes_store.Application.OrderCQRS.Command.AddCategory
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, AddCategoryResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<AddCategoryResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = new Category
            {
                Name = request.Name
            };

            await _categoryRepository.AddCategory(category);

            return new AddCategoryResult("Category added successfully");
        }
    }
}
