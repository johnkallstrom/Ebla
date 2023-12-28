namespace Ebla.Application.Authors.Queries
{
    public class GetPagedAuthorsQuery : IRequest<PagedResponse<AuthorSlimDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
