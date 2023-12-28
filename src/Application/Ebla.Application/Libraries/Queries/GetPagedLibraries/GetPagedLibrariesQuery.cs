namespace Ebla.Application.Libraries.Queries
{
    public class GetPagedLibrariesQuery : IRequest<PagedResponse<LibrarySlimDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
