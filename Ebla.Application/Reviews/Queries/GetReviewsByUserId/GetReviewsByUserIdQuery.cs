namespace Ebla.Application.Reviews.Queries.GetReviewsByUserId
{
    public class GetReviewsByUserIdQuery : IRequest<IEnumerable<ReviewResponse>>
    {
        public Guid UserId { get; set; }
    }
}
