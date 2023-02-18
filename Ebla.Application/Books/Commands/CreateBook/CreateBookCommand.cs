namespace Ebla.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime Published { get; set; }
        public bool IsReserved { get; set; }

        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
