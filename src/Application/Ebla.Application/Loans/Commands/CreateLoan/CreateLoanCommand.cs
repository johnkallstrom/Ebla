namespace Ebla.Application.Loans.Commands
{
    public class CreateLoanCommand : IRequest<Response<int>>
    {
        public int BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
