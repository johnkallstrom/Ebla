namespace Ebla.Application.UseCases.Authors.Queries
{
    public class GetAuthorsQuery : IRequest<IEnumerable<AuthorSlimDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
