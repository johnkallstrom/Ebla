namespace Ebla.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
