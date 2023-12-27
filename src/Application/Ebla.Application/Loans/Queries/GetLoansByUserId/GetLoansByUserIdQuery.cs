namespace Ebla.Application.Loans.Queries
{
    public class GetLoansByUserIdQuery : IRequest<IEnumerable<LoanDto>>
    {
        public Guid UserId { get; set; }
    }
}
