using System;
using Vita.Api.Domain.Aggregates.Categories;

namespace Vita.Api.Domain.Test.Aggregates.Categories
{
    public class CategoryBuilder
    {
        private string Name { get; set; } = "Default Name";
        private string Color { get; set; } = "#FFFFFF";
        private Guid CreatedBy { get; set; } = Guid.NewGuid();


        public Category Create()
        {
            return new Category(Name, Color, CreatedBy);
        }

        public CategoryBuilder WithCreatedBy(Guid createdBy)
        {
            CreatedBy = createdBy;
            return this;
        }

        public CategoryBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public CategoryBuilder WithColor(string color)
        {
            Color = color;
            return this;
        }
    }
}
