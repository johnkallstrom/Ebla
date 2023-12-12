namespace Ebla.Domain.Entities
{
    public class Review : BaseEntity<int>
    {
        public string Text { get; set; }
        public int Rating { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
        public Guid? UserId { get; set; }
    }
}
