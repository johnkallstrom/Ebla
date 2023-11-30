using Ebla.Application.Common.Results;

namespace Ebla.Application.Loans.Commands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
