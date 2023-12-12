namespace Ebla.Application.UseCases.Reservations.Commands
{
    public class UpdateReservationCommand : IRequest<Response>
    {
        public int Id { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
