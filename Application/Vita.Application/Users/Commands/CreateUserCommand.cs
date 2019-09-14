using Vita.Domain.Models;
using Vita.Persistance.Abstractions;

namespace Vita.Application.Users.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public CreateUserCommand(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public User Execute(string name, string email)
        {
            var user = new User()
            {
                Email = email,
                Name = name
            };



            UnitOfWork.UserRepository.Add(user);
            UnitOfWork.SaveChanges();

            return user;
        }

    }
}
