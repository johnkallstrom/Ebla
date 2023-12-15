namespace Ebla.Application.UseCases.LibraryCards.Responses
{
    public record LibraryCardDto
    {
        public int Id { get; init; }
        public int PIN { get; init; }
        public DateTime ExpiresOn { get; init; }
        public string Library { get; init; }
        public DateTime CreatedOn { get; init; }
        public DateTime? LastModified { get; init; }
        public Guid UserId { get; init; }
    }
}