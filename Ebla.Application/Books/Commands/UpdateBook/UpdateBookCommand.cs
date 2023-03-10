namespace Ebla.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<IResult<int>>
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