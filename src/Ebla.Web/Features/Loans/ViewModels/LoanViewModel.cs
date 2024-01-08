namespace Ebla.Web.Features.Loans.ViewModels
{
    public class LoanViewModel
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? Returned { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
        public BookViewModel Book { get; set; }
        public Guid UserId { get; set; }
    }
}