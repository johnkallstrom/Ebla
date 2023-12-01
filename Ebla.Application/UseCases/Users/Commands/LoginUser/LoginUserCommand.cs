namespace Ebla.Application.UseCases.Users.Commands
{
    public class LoginUserCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
