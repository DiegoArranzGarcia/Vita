using System;
using Xunit;

namespace Vita.Api.Domain.Test.Aggregates.Goals
{
    public class GoalTests
    {
        [Fact]
        public void GivenValidInput_CreatingGoal_ShouldCreateGoal()
        {
            var title = "Title";
            var description = "Description";
            var createdBy = Guid.NewGuid();


            var goal = new GoalBuilder().WithTitle(title)
                                        .WithDescription(description)
                                        .WithCreatedBy(createdBy)
                                        .Create();

            Assert.NotNull(goal);
            Assert.NotEqual(expected: Guid.Empty, actual: goal.Id);
            Assert.Equal(expected: title, actual: goal.Title);
            Assert.Equal(expected: description, actual: goal.Description);
            Assert.Equal(expected: createdBy, actual: goal.CreatedBy);
            Assert.NotEqual(expected: DateTimeOffset.MinValue, actual: goal.CreatedOn);
        }

        [Fact]
        public void GivenEmptyTitle_CreatingGoal_ShouldThrowArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new GoalBuilder().WithTitle(string.Empty)
                                                                       .Create());
        }

        [Fact]
        public void GivenNullTitle_CreatingGoal_ShouldThrowArgumentException()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => new GoalBuilder().WithTitle(null)
                                                                           .Create());
        }

        [Fact]
        public void GivenEmptyDescription_CreatingGoal_ShouldCreateTheGoal()
        {
            var goal = new GoalBuilder().WithDescription(string.Empty)
                                       .Create();

            Assert.NotNull(goal);
            Assert.Equal(expected: string.Empty, actual: goal.Description);
        }

        [Fact]
        public void GivenNullDescription_CreatingGoal_ShouldThrowArgumentException()
        {
            var goal = new GoalBuilder().WithDescription(null)
                           .Create();

            Assert.NotNull(goal);
            Assert.Null(goal.Description);
        }

        [Fact]
        public void GivenEmptyGuidCreatedBy_CreatingGoal_ShouldThrowArgumentException()
        {
            Assert.ThrowsAny<ArgumentException>(() => new GoalBuilder().WithCreatedBy(Guid.Empty)
                                                                       .Create());
        }
    }
}
