namespace Ebla.Application.UseCases.User.Queries
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public Guid Id { get; set; }
    }
}
