namespace Ebla.Application.LibraryCards.Queries.GetLibraryCardByUserId
{
    public class GetLibraryCardByUserIdQuery : IRequest<LibraryCardResponse>
    {
        public Guid UserId { get; set; }
    }
}
