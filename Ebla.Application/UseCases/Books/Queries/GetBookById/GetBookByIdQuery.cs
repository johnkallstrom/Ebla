namespace Ebla.Application.UseCases.Books.Queries
{
    public class GetBookByIdQuery : IRequest<BookResponse>
    {
        public int Id { get; set; }
    }
}
