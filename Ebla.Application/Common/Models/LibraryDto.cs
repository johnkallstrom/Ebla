namespace Ebla.Application.Common.Models
{
    public class LibraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Established { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public List<LibraryCardDto> LibraryCards { get; set; }
    }
}
