using AutoMapper;
using Vita.API.Categories;
using Vita.Domain.Categories;

namespace Vita.API.Core
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Category, CategoryDto>();
        }

    }
}
