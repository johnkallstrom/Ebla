namespace Ebla.Application.LibraryCards.Commands.DeleteLibraryCard
{
    public class DeleteLibraryCardCommand : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
