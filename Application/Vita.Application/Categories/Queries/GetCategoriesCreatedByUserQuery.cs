using MediatR;
using System;
using Vita.Application.Abstractions.Pagination;
using Vita.Application.Abstractions.Queries;

namespace Vita.Application.Categories.Queries
{
    public class GetCategoriesCreatedByUserQuery : Query, IRequest<PagedList<CategoryDto>>
    {
        public Guid CreatedBy { get; set; }
    }
}
