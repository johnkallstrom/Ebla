namespace Ebla.Application.Reviews.Queries.GetReviewsByBookId
{
    public class GetReviewsByBookIdQuery : IRequest<IEnumerable<ReviewResponse>>
    {
        public int BookId { get; set; }
    }
}
