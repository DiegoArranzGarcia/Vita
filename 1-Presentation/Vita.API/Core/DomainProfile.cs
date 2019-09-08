using AutoMapper;
using Vita.API.Categories;
using Vita.API.Users.Dtos;
using Vita.API.UsersCategories;
using Vita.Domain.Categories;
using Vita.Domain.Users;
using Vita.Domain.UsersCategories;

namespace Vita.API.Core
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserCategory, UserCategoryDto>();
        }

    }
}
