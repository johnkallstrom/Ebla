namespace Ebla.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
