namespace Ebla.Application.Loans.Queries.GetLoansByUserId
{
    public class GetLoansByUserIdQuery : IRequest<IEnumerable<LoanDto>>
    {
        public Guid UserId { get; set; }
    }
}
