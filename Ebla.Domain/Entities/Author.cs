﻿namespace Ebla.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public List<Book> Books { get; set; }
    }
}
