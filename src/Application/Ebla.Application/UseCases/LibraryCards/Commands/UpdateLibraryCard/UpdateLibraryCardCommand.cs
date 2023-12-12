namespace Ebla.Application.UseCases.LibraryCards.Commands
{
    public class UpdateLibraryCardCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public int PIN { get; set; }
        public DateTime Expires { get; set; }
    }
}
