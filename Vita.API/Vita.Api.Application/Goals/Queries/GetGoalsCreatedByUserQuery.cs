using MediatR;
using System;
using Vita.Api.Application.Pagination;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Goals.Queries
{
    public class GetGoalsCreatedByUserQuery : QueryPaginationParameters, IRequest<PagedList<GoalDto>>
    {
        public Guid CreatedBy { get; set; }
    }
}
