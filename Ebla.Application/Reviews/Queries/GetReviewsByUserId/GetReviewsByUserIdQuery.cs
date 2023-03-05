namespace Ebla.Application.Reviews.Queries.GetReviewsByUserId
{
    public class GetReviewsByUserIdQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public Guid UserId { get; set; }
    }
}
