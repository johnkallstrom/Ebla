namespace Ebla.Application.Models
{
    public class LibraryCardDto
    {
        public int Id { get; set; }
        public int PersonalIdentificationCard { get; set; }
        public DateTime Expires { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}