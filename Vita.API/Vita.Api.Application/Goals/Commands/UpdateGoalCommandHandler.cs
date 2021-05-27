using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Abstraction.Goals.Commands;
using Vita.Api.Domain.Aggregates.Dates;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Application.Sql.Goals.Commands
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, bool>
    {
        private readonly IGoalsRepository _goalsRepository;

        public UpdateGoalCommandHandler(IGoalsRepository goalsRepository)
        {
            _goalsRepository = goalsRepository;
        }

        public async Task<bool> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = await _goalsRepository.FindByIdAsync(request.Id);

            if (goal == null)
                throw new Exception("The goal wasn't found");

            goal.Title = request.Title;
            goal.Description = request.Description;
            goal.AimDate = request.AimDateStart.HasValue ? new DateTimeInterval(request.AimDateStart.Value, request.AimDateEnd.Value) : null;

            await _goalsRepository.Update(goal);
            await _goalsRepository.UnitOfWork.SaveEntitiesAsync();

            return true;
        }
    }
}
