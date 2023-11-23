namespace Ebla.Application.Common.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<IEnumerable<Loan>> GetLoansByUserIdAsync(Guid userId);
        Task<IEnumerable<Loan>> GetLoansByUserIdAsync(Guid userId, bool returned);
        Task<Loan> GetLoanByBookIdAsync(int bookId);
        Task<Loan> GetLoanByBookIdAsync(int bookId, bool returned);
    }
}
