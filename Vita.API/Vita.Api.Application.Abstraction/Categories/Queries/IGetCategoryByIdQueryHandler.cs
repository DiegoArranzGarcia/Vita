using MediatR;

namespace Vita.Api.Application.Abstraction.Categories.Queries
{
    public interface IGetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
    }
}
