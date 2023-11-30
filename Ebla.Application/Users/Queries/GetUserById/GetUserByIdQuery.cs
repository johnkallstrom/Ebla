namespace Ebla.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
    }
}
