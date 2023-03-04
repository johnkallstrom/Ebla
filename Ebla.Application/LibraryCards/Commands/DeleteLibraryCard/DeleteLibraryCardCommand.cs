namespace Ebla.Application.LibraryCards.Commands.DeleteLibraryCard
{
    public class DeleteLibraryCardCommand : IRequest<DeleteLibraryCardCommandResponse>
    {
        public int Id { get; set; }
    }
}
