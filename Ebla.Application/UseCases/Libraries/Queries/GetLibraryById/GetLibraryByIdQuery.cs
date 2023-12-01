namespace Ebla.Application.UseCases.Libraries.Queries
{
    public class GetLibraryByIdQuery : IRequest<LibraryDto>
    {
        public int Id { get; set; }
    }
}
