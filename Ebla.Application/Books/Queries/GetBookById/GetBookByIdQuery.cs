namespace Ebla.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookResponse>
    {
        public int Id { get; set; }
    }
}
