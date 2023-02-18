namespace Ebla.Application.Books.Models
{
    public class BookDto
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime Published { get; set; }
        public bool IsReserved { get; set; }
    }
}