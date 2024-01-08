namespace Ebla.Application.Users.Commands
{
    public class LoginUserCommand : IRequest<Result<string>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
