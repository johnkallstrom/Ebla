namespace Ebla.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly EblaDbContext _context;

        public LoanRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAllLoansAsync()
        {
            var loans = await _context.Loans
                .Include(x => x.Book)
                    .ThenInclude(x => x.Author)
                .Include(x => x.Book)
                    .ThenInclude(x => x.Genre)
                .ToListAsync();

            return loans;
        }

        public async Task<IEnumerable<Loan>> GetLoansByUserIdAsync(Guid userId)
        {
            var loans = await _context.Loans
                .Include(x => x.Book)
                    .ThenInclude(x => x.Author)
                .Include(x => x.Book)
                    .ThenInclude(x => x.Genre)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return loans;
        }

        public async Task<IEnumerable<Loan>> GetLoansByUserIdAsync(Guid userId, bool returned)
        {
            var loans = Enumerable.Empty<Loan>();

            if (returned)
            {
                loans = await _context.Loans
                    .Include(x => x.Book)
                    .Where(x => x.UserId == userId && x.Returned != null)
                    .ToListAsync();
            }
            else
            {
                loans = await _context.Loans
                    .Include(x => x.Book)
                    .Where(x => x.UserId == userId && x.Returned == null)
                    .ToListAsync();
            }

            return loans;
        }

        public async Task<Loan> GetLoanByBookIdAsync(int bookId)
        {
            var loan = await _context.Loans
                .Include(x => x.Book)
                .FirstOrDefaultAsync(x => x.BookId == bookId);

            return loan;
        }

        public async Task<Loan> GetLoanByBookIdAsync(int bookId, bool returned)
        {
            if (returned)
            {
                var loan = await _context.Loans
                    .Include(x => x.Book)
                    .Where(x => x.Returned != null)
                    .FirstOrDefaultAsync(x => x.BookId == bookId);

                return loan;
            }
            else
            {
                var loan = await _context.Loans
                    .Include(x => x.Book)
                    .Where(x => x.Returned == null)
                    .FirstOrDefaultAsync(x => x.BookId == bookId);

                return loan;
            }
        }
    }
}
