using Ebla.Application.Common.Results;

namespace Ebla.Application.LibraryCards.Commands.CreateLibraryCard
{
    public class CreateLibraryCardCommand : IRequest<Result<int>>
    {
        public int PIN { get; set; }
        public int LibraryId { get; set; }
        public Guid UserId { get; set; }
    }
}
