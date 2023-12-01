namespace Ebla.Persistence.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly EblaDbContext _context;

        public ReviewRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetReviewListByBookIdAsync(int bookId)
        {
            var reviews = await _context.Reviews.Where(x => x.BookId == bookId).ToListAsync();

            return reviews;
        }

        public async Task<IEnumerable<Review>> GetReviewListByUserIdAsync(Guid userId)
        {
            var reviews = await _context.Reviews.Where(x => x.UserId == userId).ToListAsync();

            return reviews;
        }
    }
}
