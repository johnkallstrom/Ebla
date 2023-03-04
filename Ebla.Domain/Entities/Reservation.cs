﻿namespace Ebla.Domain.Entities
{
    public class Reservation : BaseEntity<int>
    {
        public DateTime ExpiresOn { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        // User Reference
        public Guid? UserId { get; set; }
    }
}