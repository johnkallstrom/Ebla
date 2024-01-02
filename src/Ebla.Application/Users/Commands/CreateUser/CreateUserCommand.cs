namespace Ebla.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<Response<Guid>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
