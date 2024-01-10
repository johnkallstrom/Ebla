namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get genre percentages
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpGet("genre/{amount}")]
        public async Task<Dictionary<string, double>> GetGenrePercentages(int amount)
        {
            var data = await _mediator.Send(new GetGenrePercentagesQuery { Amount = amount });

            return data;
        }

        /// <summary>
        /// Get totals data
        /// </summary>
        /// <returns></returns>
        [HttpGet("totals")]
        public async Task<Dictionary<string, int>> GetTotals()
        {
            var data = await _mediator.Send(new GetTotalsQuery());

            return data;
        }
    }
}
