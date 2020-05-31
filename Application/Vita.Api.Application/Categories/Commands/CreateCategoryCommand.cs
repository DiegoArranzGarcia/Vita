using MediatR;
using System;

namespace Vita.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}
