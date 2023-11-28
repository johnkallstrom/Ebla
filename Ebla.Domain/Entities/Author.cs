namespace Ebla.Domain.Entities
{
    public class Author : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Born { get; set; }
        public string Country { get; set; }
        public string ImageLink { get; set; }
        public string Wikipedia { get; set; }

        public List<Book> Books { get; set; }
    }
}