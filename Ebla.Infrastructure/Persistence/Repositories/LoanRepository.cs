namespace Ebla.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly EblaDbContext _context;

        public LoanRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetActiveLoansByBookIdAsync(int bookId)
        {
            var loans = await _context.Loans
                .Include(x => x.Book)
                .Where(x => x.BookId == bookId && x.Returned == null)
                .ToListAsync();

            return loans;
        }

        public async Task<IEnumerable<Loan>> GetActiveLoansByUserIdAsync(Guid userId)
        {
            var loans = await _context.Loans
                .Include(x => x.Book)
                .Where(x => x.UserId == userId && x.Returned == null)
                .ToListAsync();

            return loans;
        }
    }
}
