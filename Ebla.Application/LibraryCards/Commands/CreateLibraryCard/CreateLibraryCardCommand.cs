namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommand : IRequest<Result<int>>
    {
        public int PersonalIdentificationNumber { get; set; }
        public int LibraryId { get; set; }
        public Guid UserId { get; set; }
    }
}
