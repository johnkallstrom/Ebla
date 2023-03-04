namespace Ebla.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly EblaDbContext _context;

        public LoanRepository(EblaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetLoanListByUserIdAsync(Guid userId)
        {
            var loans = await _context.Loans
                .Include(x => x.Book)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return loans;
        }
    }
}
