namespace Ebla.Application.UseCases.Reviews.Queries
{
    public class GetReviewsByBookIdQuery : IRequest<IEnumerable<ReviewResponse>>
    {
        public int BookId { get; set; }
    }
}
