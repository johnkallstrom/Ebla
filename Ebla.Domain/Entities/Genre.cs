namespace Ebla.Domain.Entities
{
    public class Genre : BaseEntity<int>
    {
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
