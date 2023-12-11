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
        /// Get total amount of books currently in the database
        /// </summary>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("total-books")]
        public int GetTotalAmountOfBooks()
        {
            return 0;
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
