namespace Ebla.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Unit>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
