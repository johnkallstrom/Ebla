namespace Ebla.Application.UseCases.Reviews.Queries
{
    public class GetReviewsByUserIdQuery : IRequest<IEnumerable<ReviewResponse>>
    {
        public Guid UserId { get; set; }
    }
}
