using System.Collections.Generic;
using System.Linq;
using Vita.Domain.Models;
using Vita.Persistance.Abstractions;

namespace Vita.Application.Categories.Queries
{
    public class GetAllDefaultCategoriesQuery : IGetAllDefaultCategoriesQuery
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public GetAllDefaultCategoriesQuery(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<Category> Execute()
        {
            return UnitOfWork.CategoryRepository.GetAll().Where(x => x.IsDefault);
        }
    }
}
