using Vita.Domain.Users;

namespace Vita.Application.Users.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private IUserRepository UserRepository { get; set; }

        public CreateUserCommand(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public User Execute(string name, string email)
        {
            var user = new User()
            {
                Email = email,
                Name = name
            };

            UserRepository.Add(user);
            UserRepository.Save();

            return user;
        }

    }
}
