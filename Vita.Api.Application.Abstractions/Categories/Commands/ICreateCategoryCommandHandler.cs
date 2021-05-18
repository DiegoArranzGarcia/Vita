using MediatR;
using System;
using Vita.Api.Application.Categories.Commands;

namespace Vita.Api.Application.Abstractions.Categories
{
    public interface ICreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
    }
}
