using bezoni_shoes_store.Application.Common.Errors.Admin;
using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryById(request.Id);
            if (category == null)
            {
                throw new CategoryNotFound();
            }
            await _categoryRepository.UpdateCategory(new Category
            {
                Id = request.Id,
                Name = request.Name
            });
            return Unit.Value;

        }
    }
}
