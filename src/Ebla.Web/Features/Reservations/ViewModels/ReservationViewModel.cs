﻿namespace Ebla.Web.Features.Reservations.ViewModels
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModified { get; set; }
        public BookViewModel Book { get; set; }
        public Guid UserId { get; set; }
    }
}