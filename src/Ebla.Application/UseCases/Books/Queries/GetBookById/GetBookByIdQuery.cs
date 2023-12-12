namespace Ebla.Application.UseCases.Books.Queries
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public int Id { get; set; }
    }
}
