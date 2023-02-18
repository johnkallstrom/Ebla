namespace Ebla.Application.Models
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime Published { get; set; }
        public bool IsReserved { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public AuthorDto Author { get; set; }
        public GenreDto Genre { get; set; }
    }
}