namespace Ebla.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? Returned { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}