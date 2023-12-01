namespace Ebla.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
