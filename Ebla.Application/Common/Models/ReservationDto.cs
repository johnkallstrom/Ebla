namespace Ebla.Application.Common.Models
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
        public BookSlimDto Book { get; set; }
        public Guid UserId { get; set; }
    }
}
