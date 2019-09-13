using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vita.Domain.Models;
using Vita.Persistance.Abstractions;

namespace Vita.Application.UserCategories.Queries
{
    public class GetAllUserCategoriesForUserQuery : IGetAllUserCategoriesForUserQuery
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public GetAllUserCategoriesForUserQuery(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<UserCategory> Execute(long userId)
        {
            return UnitOfWork.UserCategoryRepository.GetAll().Where(x => x.UserId == userId);
        }


    }
}
