namespace Ebla.Application.Common.Models
{
    public class LoanDto
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? Returned { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
        public int BookId { get; set; }
    }
}
