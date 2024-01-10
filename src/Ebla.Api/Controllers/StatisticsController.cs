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
        /// Get a list of percentages were each show how much of that genre exists among all books
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet("genre/{count}")]
        public async Task<Dictionary<string, double>> GetGenrePercentages(int count)
        {
            var data = await _mediator.Send(new GetGenrePercentagesQuery { Count = count });

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
