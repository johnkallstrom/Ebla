namespace Ebla.Application.UseCases.Reviews.Queries
{
    public class GetReviewsByBookIdQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public int BookId { get; set; }
    }
}
