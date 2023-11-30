namespace Ebla.Application.Loans.Commands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
