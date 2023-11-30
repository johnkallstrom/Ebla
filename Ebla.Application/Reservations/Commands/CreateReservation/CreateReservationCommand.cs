using Ebla.Application.Common.Results;

namespace Ebla.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<Result<int>>
    {
        public int BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
