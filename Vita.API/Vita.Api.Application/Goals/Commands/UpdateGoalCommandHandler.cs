using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Application.Goals.Commands
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, Goal>
    {
        private readonly IGoalsRepository _goalsRepository;

        public UpdateGoalCommandHandler(IGoalsRepository goalsRepository)
        {
            _goalsRepository = goalsRepository;
        }

        public async Task<Goal> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = await _goalsRepository.FindByIdAsync(request.Id);

            if (goal == null)
                throw new Exception("The goal wasn't found");

            goal.Title = request.Title;
            goal.Description = request.Description;

            await _goalsRepository.Update(goal);
            await _goalsRepository.UnitOfWork.SaveEntitiesAsync();

            return goal;
        }
    }
}
