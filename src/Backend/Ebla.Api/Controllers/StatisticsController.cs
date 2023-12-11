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
        /// Get statistics data
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HasReadAccess]
        [HttpGet]
        public Task<StatisticsDto> GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
