namespace Ebla.Application.LibraryCards.Commands.UpdateLibraryCard
{
    public class UpdateLibraryCardCommand : IRequest<UpdateLibraryCardCommandResponse>
    {
        public int Id { get; set; }
        public int PersonalIdentificationNumber { get; set; }
        public DateTime Expires { get; set; }
    }
}
