namespace Ebla.Application.UseCases.Authors.Queries
{
    public class GetAuthorsQuery : IRequest<PagedResponse<AuthorSlimDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
