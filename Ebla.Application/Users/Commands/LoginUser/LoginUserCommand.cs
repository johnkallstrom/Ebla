namespace Ebla.Application.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<IResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
