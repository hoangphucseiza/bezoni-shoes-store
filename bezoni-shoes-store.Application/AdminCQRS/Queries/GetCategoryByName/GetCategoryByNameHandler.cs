using bezoni_shoes_store.Application.Common.Interfaces.Persistence;
using bezoni_shoes_store.Domain.Entities;
using MediatR;

namespace bezoni_shoes_store.Application.AdminCQRS.Queries.GetCategoryByName
{
    public class GetCategoryByNameHandler : IRequestHandler<GetCategoryByNameQuery, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByNameHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryByName(request.name);
            return category;
        }
    }
}
