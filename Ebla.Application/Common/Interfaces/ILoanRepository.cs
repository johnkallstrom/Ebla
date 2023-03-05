namespace Ebla.Application.Common.Interfaces
{
    public interface ILoanRepository
    {
        Task<IEnumerable<Loan>> GetLoanListByUserIdAsync(Guid userId);
        Task<Loan> GetLoanByBookIdAsync(int bookId);
    }
}
