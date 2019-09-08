using Vita.Domain.Categories;
using Vita.Domain.Users;

namespace Vita.Domain.UsersGoals
{
    public class UserGoal
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
