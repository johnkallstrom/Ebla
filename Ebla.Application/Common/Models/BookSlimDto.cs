namespace Ebla.Application.Common.Models
{
    public class BookSlimDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime Published { get; set; }
        public string Language { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
