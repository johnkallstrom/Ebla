﻿namespace Ebla.Application.Common.Models
{
    public class LibraryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public DateTime? Established { get; set; }
        public string Website { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }

        public List<BookDto> Books { get; set; }
    }
}
