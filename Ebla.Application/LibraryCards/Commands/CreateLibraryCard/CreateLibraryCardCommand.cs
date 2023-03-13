namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommand : IRequest<IResult<int>>
    {
        public int PersonalIdentificationNumber { get; set; }
        public Guid UserId { get; set; }
    }
}
