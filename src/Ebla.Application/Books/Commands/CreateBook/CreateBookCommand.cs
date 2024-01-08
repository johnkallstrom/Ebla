namespace Ebla.Application.Books.Commands
{
    public class CreateBookCommand : IRequest<Result<int>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public DateTime Published { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }

        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int[] LibraryIds { get; set; }
    }
}