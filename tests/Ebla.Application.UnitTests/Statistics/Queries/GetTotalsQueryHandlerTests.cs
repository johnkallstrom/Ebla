namespace Ebla.Application.UnitTests.Statistics.Queries
{
    public class GetTotalsQueryHandlerTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IIdentityService> _mockIdentityService;
        private readonly Mock<ILoanRepository> _mockLoanRepository;
        private readonly Mock<IReservationRepository> _mockReservationRepository;

        public GetTotalsQueryHandlerTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockIdentityService = new Mock<IIdentityService>();
            _mockLoanRepository = new Mock<ILoanRepository>();
            _mockReservationRepository = new Mock<IReservationRepository>();
        }

        [Fact]
        public async Task Handle_Should_ReturnDictionaryWithKeysAsTypeString()
        {
            // Arrange
            SetupMocks();

            var request = new GetTotalsQuery();
            var handler = new GetTotalsQueryHandler(
                _mockBookRepository.Object, 
                _mockIdentityService.Object,
                _mockLoanRepository.Object,
                _mockReservationRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Keys.Should().AllBeOfType<string>();
        }

        [Fact]
        public async Task Handle_Should_ReturnDictionaryWithValuesAsTypeInt()
        {
            // Arrange
            SetupMocks();

            var request = new GetTotalsQuery();
            var handler = new GetTotalsQueryHandler(
                _mockBookRepository.Object,
                _mockIdentityService.Object,
                _mockLoanRepository.Object,
                _mockReservationRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Values.Should().AllBeOfType<int>();
        }

        #region Helpers
        private void SetupMocks()
        {
            _mockBookRepository.Setup(x => x.GetTotalBooksAsync()).ReturnsAsync(50);
            _mockIdentityService.Setup(x => x.GetTotalUsersAsync()).ReturnsAsync(2);
            _mockLoanRepository.Setup(x => x.GetTotalLoansAsync()).ReturnsAsync(10);
            _mockReservationRepository.Setup(x => x.GetTotalReservationsAsync()).ReturnsAsync(15);
        }
        #endregion
    }
}