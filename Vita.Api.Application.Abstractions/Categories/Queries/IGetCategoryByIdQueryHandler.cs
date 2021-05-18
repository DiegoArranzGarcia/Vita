using MediatR;
using Vita.Api.Application.Categories.Queries;

namespace Vita.Api.Application.Abstractions.Categories.Queries
{
    public interface IGetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
    }
}
