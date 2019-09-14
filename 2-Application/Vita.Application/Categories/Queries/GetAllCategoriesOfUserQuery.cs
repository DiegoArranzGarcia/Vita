using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vita.Domain.Models;
using Vita.Persistance.Abstractions;

namespace Vita.Application.Categories.Queries
{
    public class GetAllUserCategoriesOfUserQuery : IGetAllCategoriesOfUserQuery
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public GetAllUserCategoriesOfUserQuery(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<Category> Execute(long userId)
        {
            return UnitOfWork.UserCategoryRepository.GetAll().Where(x => x.UserId == userId).Select(x => x.Category);
        }
    }
}
