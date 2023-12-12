namespace Ebla.Application.Interfaces.DataAccess
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewListByBookIdAsync(int bookId);
        Task<IEnumerable<Review>> GetReviewListByUserIdAsync(Guid userId);
    }
}
