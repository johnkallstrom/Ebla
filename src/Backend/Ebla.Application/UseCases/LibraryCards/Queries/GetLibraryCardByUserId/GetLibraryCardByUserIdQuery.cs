namespace Ebla.Application.UseCases.LibraryCards.Queries
{
    public class GetLibraryCardByUserIdQuery : IRequest<LibraryCardDto>
    {
        public Guid UserId { get; set; }
    }
}
