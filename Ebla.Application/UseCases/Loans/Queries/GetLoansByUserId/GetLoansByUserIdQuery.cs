namespace Ebla.Application.UseCases.Loans.Queries
{
    public class GetLoansByUserIdQuery : IRequest<IEnumerable<LoanResponse>>
    {
        public Guid UserId { get; set; }
    }
}
