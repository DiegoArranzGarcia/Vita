using MediatR;
using System;

namespace Vita.Api.Application.Abstraction.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}
