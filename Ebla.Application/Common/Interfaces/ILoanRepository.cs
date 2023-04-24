namespace Ebla.Application.Common.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetActiveLoansByUserIdAsync(Guid userId);
        Task<IEnumerable<Loan>> GetActiveLoansByBookIdAsync(int bookId);
    }
}
