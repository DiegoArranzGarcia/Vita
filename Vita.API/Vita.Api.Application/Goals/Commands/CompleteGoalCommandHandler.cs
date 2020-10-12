using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Application.Goals.Commands
{
    public class CompleteGoalCommandHandler : IRequestHandler<CompleteGoalCommand, bool>
    {
        private readonly IGoalsRepository _goalsRepository;

        public CompleteGoalCommandHandler(IGoalsRepository goalsRepository)
        {
            _goalsRepository = goalsRepository;
        }

        public async Task<bool> Handle(CompleteGoalCommand command, CancellationToken cancellationToken)
        {
            var goal = await _goalsRepository.FindByIdAsync(command.Id);

            if (goal == null)
                throw new Exception("The goal wasn't found");

            goal.Complete();

            await _goalsRepository.Update(goal);
            await _goalsRepository.UnitOfWork.SaveEntitiesAsync();

            return true;
        }
    }
}
