namespace Ebla.Application.Libraries.Queries
{
    public class GetLibrariesQuery : IRequest<PagedResponse<LibrarySlimDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
