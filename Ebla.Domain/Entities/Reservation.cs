namespace Ebla.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}