using Ebla.Application.Common.Results;

namespace Ebla.Application.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
