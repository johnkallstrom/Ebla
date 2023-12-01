namespace Ebla.Application.UseCases.User.Commands
{
    public class UpdateUserCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
