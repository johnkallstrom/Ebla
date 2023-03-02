namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommand : IRequest<Unit>
    {
        public int PersonalIdentificationNumber { get; set; }
        public DateTime Expires { get; set; }
        public Guid UserId { get; set; }
    }
}
