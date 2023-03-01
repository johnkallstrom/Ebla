namespace Ebla.Application.Common.Models
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string Book { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public UserDto User { get; set; }
    }
}
