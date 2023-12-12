namespace Ebla.Application.UseCases.Loans.Queries
{
    public class GetLoansByUserIdQuery : IRequest<IEnumerable<LoanDto>>
    {
        public Guid UserId { get; set; }
    }
}
