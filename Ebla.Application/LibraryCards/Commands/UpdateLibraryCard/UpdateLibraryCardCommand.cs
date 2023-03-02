namespace Ebla.Application.LibraryCards.Commands.UpdateLibraryCard
{
    public class UpdateLibraryCardCommand : IRequest<UpdateLibraryCardCommandResponse>
    {
        public int PersonalIdentificationNumber { get; set; }
        public DateTime Expires { get; set; }
        public Guid UserId { get; set; }
    }
}
