namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommand : IRequest<Response<int>>
    {
        public int PIN { get; set; }
        public int LibraryId { get; set; }
        public Guid UserId { get; set; }
    }
}
