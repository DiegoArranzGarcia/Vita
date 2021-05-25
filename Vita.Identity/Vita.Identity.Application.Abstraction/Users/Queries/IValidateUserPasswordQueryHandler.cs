using MediatR;

namespace Vita.Identity.Application.Abstraction.Users.Queries
{
    public interface IValidateUserPasswordQueryHandler : IRequestHandler<ValidateUserPasswordQuery, bool>
    {
    }
}
