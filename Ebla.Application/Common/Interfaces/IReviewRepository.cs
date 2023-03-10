namespace Ebla.Application.Common.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewListByBookIdAsync(int bookId);
        Task<IEnumerable<Review>> GetReviewListByUserIdAsync(Guid userId);
    }
}
