namespace Ebla.Application.LibraryCards.Commands.DeleteLibraryCard
{
    public class DeleteLibraryCardCommand : IRequest<IResult<int>>
    {
        public int Id { get; set; }
    }
}
