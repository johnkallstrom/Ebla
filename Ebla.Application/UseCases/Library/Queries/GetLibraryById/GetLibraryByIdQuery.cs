namespace Ebla.Application.UseCases.Library.Queries
{
    public class GetLibraryByIdQuery : IRequest<LibraryResponse>
    {
        public int Id { get; set; }
    }
}
