namespace Ebla.Application.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
    }
}
