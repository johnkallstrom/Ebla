using Ebla.Application.Common.Results;

namespace Ebla.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}
