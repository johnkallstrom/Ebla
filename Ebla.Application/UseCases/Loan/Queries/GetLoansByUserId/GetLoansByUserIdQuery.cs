namespace Ebla.Application.UseCases.Loan.Queries
{
    public class GetLoansByUserIdQuery : IRequest<IEnumerable<LoanResponse>>
    {
        public Guid UserId { get; set; }
    }
}
