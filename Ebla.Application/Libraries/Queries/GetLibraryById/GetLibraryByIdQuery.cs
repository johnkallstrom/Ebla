namespace Ebla.Application.Libraries.Queries.GetLibraryById
{
    public class GetLibraryByIdQuery : IRequest<LibraryDto>
    {
        public int Id { get; set; }
    }
}
