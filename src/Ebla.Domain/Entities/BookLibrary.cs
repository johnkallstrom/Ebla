namespace Ebla.Domain.Entities
{
    public class BookLibrary
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
