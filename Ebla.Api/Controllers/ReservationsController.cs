﻿namespace Ebla.Api.Controllers
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
        /// Get all user reservations
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IEnumerable<ReservationDto>> GetByUserId(Guid userId)
        {
            var reservations = await _mediator.Send(new GetReservationsByUserIdQuery { UserId = userId });

            return reservations;
        }

        /// <summary>
        /// Create a new reservation
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<CreateReservationCommandResponse> Create([FromBody] CreateReservationCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }
    }
}
