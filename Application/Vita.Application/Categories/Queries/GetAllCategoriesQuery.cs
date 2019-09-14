using System.Collections.Generic;
using Vita.Domain.Models;
using Vita.Persistance.Abstractions;

namespace Vita.Application.Categories.Queries
{
    public class GetAllCategoriesQuery : IGetAllCategoriesQuery
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public GetAllCategoriesQuery(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<Category> Execute()
        {
            return UnitOfWork.CategoryRepository.GetAll();
        }
    }
}
