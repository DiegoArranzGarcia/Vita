using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vita.Domain.Models;
using Vita.Persistance.Abstractions;

namespace Vita.Application.Categories.Queries
{
    public class GetAllCategoriesOfUserQuery : IGetAllCategoriesOfUserQuery
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public GetAllCategoriesOfUserQuery(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<Category> Execute(long userId)
        {
            var a = UnitOfWork.UserCategoryRepository.GetAll().Where(x => x.UserId == userId).ToList();
            return a.Select(x => x.Category);
        }
    }
}
