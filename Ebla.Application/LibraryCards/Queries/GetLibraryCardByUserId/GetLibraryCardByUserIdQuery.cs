namespace Ebla.Application.LibraryCards.Queries.GetLibraryCardByUserId
{
    public class GetLibraryCardByUserIdQuery : IRequest<LibraryCardDto>
    {
        public Guid UserId { get; set; }
    }
}
