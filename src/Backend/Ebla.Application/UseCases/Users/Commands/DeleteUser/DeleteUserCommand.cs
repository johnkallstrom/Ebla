namespace Ebla.Application.UseCases.Users.Commands
{
    public class DeleteUserCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
