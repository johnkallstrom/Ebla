namespace Ebla.Application.Books.Responses
{
    public record BookSlimDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string Genre { get; init; }
        public string Language { get; init; }
        public string Country { get; init; }
        public string Image { get; init; }
    }
}