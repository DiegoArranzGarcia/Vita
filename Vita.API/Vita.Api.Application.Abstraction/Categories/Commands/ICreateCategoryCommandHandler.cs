using MediatR;
using System;

namespace Vita.Api.Application.Abstraction.Categories.Commands
{
    public interface ICreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
    }
}
