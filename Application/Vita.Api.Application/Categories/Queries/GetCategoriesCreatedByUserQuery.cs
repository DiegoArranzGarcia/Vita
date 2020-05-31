using MediatR;
using System;
using Vita.Api.Application.Pagination;
using Vita.Core.Pagination;

namespace Vita.Application.Categories.Queries
{
    public class GetCategoriesCreatedByUserQuery : QueryPaginationParameters, IRequest<PagedList<CategoryDto>>
    {
        public Guid CreatedBy { get; set; }
    }
}
