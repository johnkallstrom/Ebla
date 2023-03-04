namespace Ebla.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly EblaDbContext _context;

        public LoanRepository(EblaDbContext context)
        {
            _context = context;
        }
    }
}
