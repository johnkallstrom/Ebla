namespace Ebla.Application.Loans.Commands
{
    public class UpdateLoanCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? Returned { get; set; }
    }
}
