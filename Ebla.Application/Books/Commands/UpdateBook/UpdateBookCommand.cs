namespace Ebla.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime Published { get; set; }
        public bool IsReserved { get; set; }

        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
