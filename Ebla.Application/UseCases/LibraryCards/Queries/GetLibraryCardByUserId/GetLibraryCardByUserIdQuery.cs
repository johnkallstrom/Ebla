namespace Ebla.Application.UseCases.LibraryCards.Queries
{
    public class GetLibraryCardByUserIdQuery : IRequest<LibraryCardResponse>
    {
        public Guid UserId { get; set; }
    }
}
