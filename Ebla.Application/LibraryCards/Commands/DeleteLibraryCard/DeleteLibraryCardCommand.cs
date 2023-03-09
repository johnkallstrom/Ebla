namespace Ebla.Application.LibraryCards.Commands.DeleteLibraryCard
{
    public class DeleteLibraryCardCommand : IRequest<IResult>
    {
        public int Id { get; set; }
    }
}
