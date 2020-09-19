using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Application.Goals.Commands
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
            
            goal.ChangeTitle(request.Title);
            goal.ChangeDescription(request.Description);

            await _goalsRepository.Update(goal);
            return await _goalsRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
