namespace Ebla.Application.LibraryCards.Commands.UpdateLibraryCard
{
    public class UpdateLibraryCardCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public int PIN { get; set; }
        public DateTime Expires { get; set; }
    }
}
