using MediatR;
using System;
using Vita.Api.Application.Abstractions.Pagination;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Abstraction.Categories.Queries
{
    public class GetCategoriesCreatedByUserQuery : QueryPaginationParameters, IRequest<PagedList<CategoryDto>>
    {
        public Guid CreatedBy { get; set; }
    }
}
