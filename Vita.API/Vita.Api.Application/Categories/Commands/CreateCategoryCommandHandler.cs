using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Abstraction.Categories.Commands;
using Vita.Api.Domain.Aggregates.Categories;

namespace Vita.Api.Application.Sql.Categories
{
    public class CreateCategoryCommandHandler : ICreateCategoryCommandHandler
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CreateCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name, request.Color, request.CreatedBy);

            await _categoriesRepository.Add(category);
            await _categoriesRepository.UnitOfWork.SaveEntitiesAsync();

            return category.Id;
        }
    }
}
