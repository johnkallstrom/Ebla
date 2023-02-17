namespace Ebla.Domain.Entities
{
    public class Reservation : BaseEntity<int>
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}