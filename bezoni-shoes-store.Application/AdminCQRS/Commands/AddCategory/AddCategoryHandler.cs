using bezoni_shoes_store.Application.AdminCQRS.Common;
using bezoni_shoes_store.Application.Common.Errors.Admin;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.AddCategory
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, AddCategoryResult>
    {
        public ICategoryRepository _categoryRepository;
        public AddCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<AddCategoryResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByName(request.Name);

            if (category != null)
            {
                throw new CategoryExist();
            }

            var newCategory = new Category
            {
                Name = request.Name
            };

            await _categoryRepository.AddCategory(newCategory);

            return new AddCategoryResult("Create Category Success");

        }
    }
}
