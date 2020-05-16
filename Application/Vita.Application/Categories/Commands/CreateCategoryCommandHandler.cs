using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Vita.Domain.Aggregates.Categories;

namespace Vita.Application.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CreateCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name, request.Color, request.CreatedBy);
            await _categoriesRepository.Add(category);

            return await _categoriesRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
