namespace Ebla.Application.Common.Models
{
    public class ReservationDto
    {
        public DateTime ExpiresOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public UserDto User { get; set; }
    }
}
