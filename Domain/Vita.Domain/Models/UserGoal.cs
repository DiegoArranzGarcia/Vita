namespace Vita.Domain.Models
{
    public class UserGoal
    {
        public long Id { get; set; }
        public long GoalId { get; set; }
        public virtual Goal Goal { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
