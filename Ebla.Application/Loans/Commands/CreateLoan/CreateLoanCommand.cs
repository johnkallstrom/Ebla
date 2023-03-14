namespace Ebla.Application.Loans.Commands.CreateLoan
{
    public class CreateLoanCommand : IRequest<Result<int>>
    {
        public int BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
