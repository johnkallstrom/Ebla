namespace Ebla.Application.UseCases.Books.Responses
{
    public record BookDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public int Pages { get; init; }
        public string Author { get; init; }
        public string Genre { get; init; }
        public DateTime Published { get; init; }
        public string Language { get; init; }
        public string Country { get; init; }
        public string ImageLink { get; init; }
        public string Wikipedia { get; init; }
        public DateTime CreatedOn { get; init; }
        public DateTime? LastModified { get; init; }

        public List<ReviewDto> Reviews { get; init; }
        public List<ReservationDto> Reservations { get; init; }
    }
}