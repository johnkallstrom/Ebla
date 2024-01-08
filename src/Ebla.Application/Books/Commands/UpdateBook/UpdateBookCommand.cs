namespace Ebla.Application.Books.Commands
{
    public class UpdateBookCommand : IRequest<Result>
    {
        public int Id { get; set; }
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