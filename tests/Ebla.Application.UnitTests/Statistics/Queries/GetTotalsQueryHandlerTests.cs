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
        public async Task Handle_Should_InvokeGetTotalReservationsAsyncOnce()
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
            _mockReservationRepository.Verify(x => x.GetTotalReservationsAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_InvokeGetTotalLoansAsyncOnce()
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
            _mockLoanRepository.Verify(x => x.GetTotalLoansAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_InvokeGetTotalUsersAsyncOnce()
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
            _mockIdentityService.Verify(x => x.GetTotalUsersAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_InvokeGetTotalBooksAsyncOnce()
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
            _mockBookRepository.Verify(x => x.GetTotalBooksAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_ReturnDictionaryWithKeysAsTypeStringAndValuesAsTypeInt()
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
            result.Should().BeOfType<Dictionary<string, int>>();
            result.Keys.Should().AllBeOfType<string>();
            result.Values.Should().AllBeOfType<int>();
        }

        [Fact]
        public async Task Handle_Should_ReturnNotNullOrEmptyDictionary()
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
            result.Should().NotBeNullOrEmpty();
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