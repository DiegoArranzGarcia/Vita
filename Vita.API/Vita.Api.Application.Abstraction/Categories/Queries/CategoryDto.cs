using System;

namespace Vita.Api.Application.Abstraction.Categories.Queries
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}