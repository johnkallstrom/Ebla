namespace Ebla.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
