namespace Ebla.Application.UseCases.LibraryCard.Commands
{
    public class CreateLibraryCardCommand : IRequest<Response<int>>
    {
        public int PIN { get; set; }
        public int LibraryId { get; set; }
        public Guid UserId { get; set; }
    }
}
