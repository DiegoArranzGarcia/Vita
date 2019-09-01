using System;
using Vita.Domain.Categories;
using Vita.Domain.Users;

namespace Vita.Domain.UsersCategories
{
    public class UserCategory
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
