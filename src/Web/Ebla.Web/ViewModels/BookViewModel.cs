namespace Ebla.Web.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime Published { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
