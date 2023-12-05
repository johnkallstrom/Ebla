namespace Ebla.Application.UseCases.Loans.Commands
{
    public class DeleteLoanCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
