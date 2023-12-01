namespace Ebla.Application.UseCases.Review.Queries
{
    public class GetReviewsByBookIdQuery : IRequest<IEnumerable<ReviewResponse>>
    {
        public int BookId { get; set; }
    }
}
