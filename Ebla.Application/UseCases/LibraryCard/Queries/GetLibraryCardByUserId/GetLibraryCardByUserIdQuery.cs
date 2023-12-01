namespace Ebla.Application.UseCases.LibraryCard.Queries
{
    public class GetLibraryCardByUserIdQuery : IRequest<LibraryCardResponse>
    {
        public Guid UserId { get; set; }
    }
}
