using Ebla.Application.Models;

namespace Ebla.Application.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public int Id { get; set; }
    }
}
