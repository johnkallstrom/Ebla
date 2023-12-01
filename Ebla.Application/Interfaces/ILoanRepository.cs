namespace Ebla.Application.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Domain.Entities.Loan>> GetAllLoansAsync();
        Task<IEnumerable<Domain.Entities.Loan>> GetLoansByUserIdAsync(Guid userId);
        Task<IEnumerable<Domain.Entities.Loan>> GetLoansByUserIdAsync(Guid userId, bool returned);
        Task<Domain.Entities.Loan> GetLoanByBookIdAsync(int bookId);
        Task<Domain.Entities.Loan> GetLoanByBookIdAsync(int bookId, bool returned);
    }
}
