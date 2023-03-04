namespace Ebla.Application.Common.Models
{
    public class LibraryCardDto
    {
        public int Id { get; set; }
        public int PersonalIdentificationNumber { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
    }
}