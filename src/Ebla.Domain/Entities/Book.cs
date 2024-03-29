﻿namespace Ebla.Domain.Entities
{
    public class Book : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public DateTime Published { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<BookLibrary> BookLibraries { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}