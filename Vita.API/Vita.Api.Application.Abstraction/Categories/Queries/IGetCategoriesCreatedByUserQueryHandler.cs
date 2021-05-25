using MediatR;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Abstraction.Categories.Queries
{
    public interface IGetCategoriesCreatedByUserQueryHandler : IRequestHandler<GetCategoriesCreatedByUserQuery, PagedList<CategoryDto>>
    {
    }
}
