namespace Ebla.Application.UseCases.User.Commands
{
    public class DeleteUserCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
