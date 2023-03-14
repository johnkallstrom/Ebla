namespace Ebla.Application.LibraryCards.Commands.DeleteLibraryCard
{
    public class DeleteLibraryCardCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
