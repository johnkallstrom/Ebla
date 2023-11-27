namespace Ebla.Domain.Entities
{
    public class BookLibrary : BaseEntity<int>
    {
        public int BookId { get; set; }
        public int LibraryId { get; set; }
    }
}
