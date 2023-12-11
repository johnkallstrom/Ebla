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
        public async Task<StatisticsDto> GetStatistics()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get total amount of books currently in the database
        /// </summary>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("total-books")]
        public async Task<int> GetTotalAmountOfBooks()
        {
            var response = await _mediator.Send(new GetTotalAmountOfBooksQuery());

            return response;
        }

        /// <summary>
        /// Get top three genres with most books in percentage
        /// </summary>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("genres")]
        public double[] GetTop3GenresWithMostBooks()
        {
            return [50, 35, 15];
        }
    }
}
