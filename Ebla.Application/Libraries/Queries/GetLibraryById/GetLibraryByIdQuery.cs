namespace Ebla.Application.Libraries.Queries.GetLibraryById
{
    public class GetLibraryByIdQuery : IRequest<LibraryResponse>
    {
        public int Id { get; set; }
    }
}
