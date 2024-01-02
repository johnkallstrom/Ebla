namespace Ebla.Application.Reservations.Commands
{
    public class CreateReservationCommand : IRequest<Response<int>>
    {
        public int BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
