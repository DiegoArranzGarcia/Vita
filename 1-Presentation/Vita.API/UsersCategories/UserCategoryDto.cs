using Vita.API.Categories;
using Vita.API.Users;

namespace Vita.API.UsersCategories
{
    public class UserCategoryDto
    {
        public long Id { get; set; }
        public UserDto User { get; set; }
        public CategoryDto Category { get; set; }
    }
}