namespace Ebla.Web.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Born { get; set; }
        public string ImageUrl { get; set; }
        public string Wikipedia { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}