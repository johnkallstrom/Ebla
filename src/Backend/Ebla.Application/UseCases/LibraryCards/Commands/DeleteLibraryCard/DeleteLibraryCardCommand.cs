namespace Ebla.Application.UseCases.LibraryCards.Commands
{
    public class DeleteLibraryCardCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
