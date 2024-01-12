namespace Ebla.Application.UnitTests.Statistics.Queries
{
    public class GetTotalsQueryHandler
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IIdentityService> _mockIdentityService;
        private readonly Mock<ILoanRepository> _mockLoanRepository;
        private readonly Mock<IReservationRepository> _mockReservationRepository;

        public GetTotalsQueryHandler()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockIdentityService = new Mock<IIdentityService>();
            _mockLoanRepository = new Mock<ILoanRepository>();
            _mockReservationRepository = new Mock<IReservationRepository>();
        }

        [Fact]
        public Task Handle_Should_ReturnDictionaryWithKeysAsTypeString()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public Task Handle_Should_ReturnDictionaryWithValuesAsTypeInt()
        {
            throw new NotImplementedException();
        }
    }
}