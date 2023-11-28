﻿namespace Ebla.Application.Common.Models
{
    public class LibraryCardDto
    {
        public int Id { get; set; }
        public int PIN { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid UserId { get; set; }
    }
}