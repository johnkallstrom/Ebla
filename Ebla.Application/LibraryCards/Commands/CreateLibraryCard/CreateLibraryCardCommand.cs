namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommand : IRequest<CreateLibraryCommandCardResponse>
    {
        public int PersonalIdentificationNumber { get; set; }
        public Guid UserId { get; set; }
    }
}
