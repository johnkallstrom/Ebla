namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet]
        public async Task<IEnumerable<ReservationResponse>> GetAll()
        {
            var reservations = await _mediator.Send(new GetReservationsQuery());

            return reservations;
        }

        /// <summary>
        /// Get all user reservations
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("{userId}")]
        public async Task<IEnumerable<ReservationResponse>> GetByUserId(Guid userId)
        {
            var reservations = await _mediator.Send(new GetReservationsByUserIdQuery { UserId = userId });

            return reservations;
        }

        /// <summary>
        /// Create a new reservation
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPost("create")]
        public async Task<Response<int>> Create([FromBody] CreateReservationCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }

        /// <summary>
        /// Update a reservation
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPut]
        public async Task<Response> Update([FromBody] UpdateReservationCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }

        /// <summary>
        /// Delete a reservation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpDelete("delete/{id}")]
        public async Task<Response> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteReservationCommand { Id = id });

            return response;
        }

    }
}
