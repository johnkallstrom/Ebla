namespace Ebla.Application.Loans.Queries.GetLoansByUserId
{
    public class GetLoansByUserIdQuery : IRequest<IEnumerable<LoanResponse>>
    {
        public Guid UserId { get; set; }
    }
}
