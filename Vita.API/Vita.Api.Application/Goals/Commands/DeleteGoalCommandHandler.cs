using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Abstraction.Goals.Commands;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Application.Sql.Goals.Commands
{
    public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand, bool>
    {
        private readonly IGoalsRepository _goalsRepository;

        public DeleteGoalCommandHandler(IGoalsRepository goalsRepository)
        {
            _goalsRepository = goalsRepository;
        }

        public async Task<bool> Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
        {
            await _goalsRepository.Delete(request.Id);
            return await _goalsRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
