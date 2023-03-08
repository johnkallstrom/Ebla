namespace Ebla.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<IResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public DateTime Published { get; set; }
        public string Language { get; set; }
        public bool IsReserved { get; set; }

        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}