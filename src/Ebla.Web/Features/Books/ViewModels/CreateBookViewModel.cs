namespace Ebla.Web.Features.Books.ViewModels
{
    public record CreateBookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public DateTime? Published { get; set; }
    }
}
