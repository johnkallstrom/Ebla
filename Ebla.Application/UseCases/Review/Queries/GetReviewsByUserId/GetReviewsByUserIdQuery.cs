namespace Ebla.Application.UseCases.Review.Queries
{
    public class GetReviewsByUserIdQuery : IRequest<IEnumerable<ReviewResponse>>
    {
        public Guid UserId { get; set; }
    }
}
