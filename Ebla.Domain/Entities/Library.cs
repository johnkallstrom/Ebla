namespace Ebla.Domain.Entities
{
    public class Library : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public DateTime? Established { get; set; }
        public string Website { get; set; }

        public List<Book> Books { get; set; }
    }
}
