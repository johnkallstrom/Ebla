namespace Ebla.Application.UseCases.Libraries.Queries
{
    public class GetLibraryByIdQuery : IRequest<LibraryResponse>
    {
        public int Id { get; set; }
    }
}
