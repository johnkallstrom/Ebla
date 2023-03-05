namespace Ebla.Application.Reviews.Queries.GetReviewsByBookId
{
    public class GetReviewsByBookIdQuery : IRequest<IEnumerable<ReviewDto>>
    {
        public int BookId { get; set; }
    }
}
