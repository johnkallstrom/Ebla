namespace Ebla.Domain.Entities
{
    public class Author : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public List<Book> Books { get; set; }
    }
}
