namespace Ebla.Application.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
