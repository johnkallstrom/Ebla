namespace Ebla.Application.UseCases.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
    }
}
