namespace Ebla.Application.Common.Models
{
    public class BookDto
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
        public string ImageLink { get; set; }
        public string Wikipedia { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public List<ReviewDto> Reviews { get; set; }
        public List<ReservationDto> Reservations { get; set; }
    }
}