namespace Ebla.Application.UseCases.LibraryCard.Commands
{
    public class DeleteLibraryCardCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
