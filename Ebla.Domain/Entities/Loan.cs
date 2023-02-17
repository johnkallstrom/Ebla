namespace Ebla.Domain.Entities
{
    public class Loan : BaseEntity<int>
    {
        public DateTime DueDate { get; set; }
        public DateTime? Returned { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        // User Reference
        public Guid? UserId { get; set; }
    }
}