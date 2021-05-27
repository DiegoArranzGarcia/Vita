using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Vita.Api.Domain.Test.Aggregates.Categories
{
    public class CategoryTests
    {
        [Fact]
        public void GivenValidInput_CreatingCategory_ShouldCreateCategory()
        {
            var name = "Category Name";
            var color = "#FFFFFF";
            var createdBy = Guid.NewGuid();

            var category = new CategoryBuilder().WithName(name)
                                                .WithColor(color)
                                                .WithCreatedBy(createdBy)
                                                .Create();

            Assert.NotNull(category);
            Assert.NotEqual(expected: Guid.Empty, actual: category.Id);
            Assert.Equal(expected: name, actual: category.Name);
            Assert.Equal(expected: color, actual: category.Color);
            Assert.Equal(expected: createdBy, actual: category.CreatedBy);            
        }

        [Fact]
        public void GivenEmptyName_CreatingCategory_ShouldThrowArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new CategoryBuilder().WithName(string.Empty)
                                                                           .Create());
        }

        [Fact]
        public void GivenNullTitle_CreatingCategory_ShouldThrowArgumentException()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => new CategoryBuilder().WithName(null)
                                                                               .Create());
        }

        [Fact]
        public void GivenEmptyColor_CreatingCategory_ShouldThrowArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new CategoryBuilder().WithColor(string.Empty)
                                                                           .Create());
        }

        [Fact]
        public void GivenNullColor_CreatingCategory_ShouldThrowArgumentException()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => new CategoryBuilder().WithColor(null)
                                                                               .Create());
        }

        [Fact]
        public void GivenEmptyGuidCreatedBy_CreatingCategory_ShouldThrowArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new CategoryBuilder().WithCreatedBy(Guid.Empty)
                                                                           .Create());
        }
    }
}
