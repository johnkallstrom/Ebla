namespace Ebla.Application.Reviews.Queries
{
    public class GetReviewsByUserIdQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public Guid UserId { get; set; }
    }
}
