namespace Ebla.Domain.Entities
{
    public class Library : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime? Established { get; set; }

        public ICollection<BookLibrary> BookLibraries { get; set; }
        public List<LibraryCard> LibraryCards { get; set; }
    }
}
