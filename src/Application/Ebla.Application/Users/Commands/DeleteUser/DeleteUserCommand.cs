namespace Ebla.Application.Users.Commands
{
    public class DeleteUserCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
