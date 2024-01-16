namespace Ebla.Web.Features.Books.ViewModels
{
    public record CreateBookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; } = 1;
        public DateTime? Published { get; set; } = new DateTime(1900, 1, 1);
        public string Language { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public int[] LibraryIds { get; set; }
    }
}
