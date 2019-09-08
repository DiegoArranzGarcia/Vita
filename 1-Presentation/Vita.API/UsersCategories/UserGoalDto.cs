using Vita.API.Categories;
using Vita.API.Users.Dtos;

namespace Vita.API.UsersCategories
{
    public class UserGoalDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UserDto User { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}