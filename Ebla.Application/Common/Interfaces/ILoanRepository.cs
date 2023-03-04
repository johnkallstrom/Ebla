namespace Ebla.Application.Common.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> GetLoanByBookIdAsync(int bookId);
    }
}
