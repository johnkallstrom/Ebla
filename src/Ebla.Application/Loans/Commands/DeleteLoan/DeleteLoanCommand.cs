namespace Ebla.Application.Loans.Commands
{
    public class DeleteLoanCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
