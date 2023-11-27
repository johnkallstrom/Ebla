namespace Ebla.Application.Common.Models
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
