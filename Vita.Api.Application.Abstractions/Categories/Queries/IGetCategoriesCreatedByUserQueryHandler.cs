using MediatR;
using Vita.Api.Application.Categories.Queries;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Abstractions.Categories.Queries
{
    public interface IGetCategoriesCreatedByUserQueryHandler : IRequestHandler<GetCategoriesCreatedByUserQuery, PagedList<CategoryDto>>
    {
    }
}
