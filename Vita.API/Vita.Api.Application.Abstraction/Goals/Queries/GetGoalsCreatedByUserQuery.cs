using MediatR;
using System;
using Vita.Api.Application.Abstraction.Goals.Queries;
using Vita.Api.Application.Abstractions.Pagination;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Goals.Queries
{
    public class GetGoalsCreatedByUserQuery : QueryPaginationParameters, IRequest<PagedList<GoalDto>>
    {
        public Guid CreatedBy { get; set; }
        public bool? ShowCompleted { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
