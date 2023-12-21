namespace Ebla.Application.UseCases.Books.Queries
{
    public class GetBooksQuery : IRequest<PagedResponse<BookSlimDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
