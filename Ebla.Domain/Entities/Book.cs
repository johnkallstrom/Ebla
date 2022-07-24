namespace Ebla.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime Published { get; set; }
        public bool IsReserved { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
