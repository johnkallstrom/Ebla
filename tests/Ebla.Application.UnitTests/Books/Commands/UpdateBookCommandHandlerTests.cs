namespace Ebla.Application.UnitTests.Books.Commands
{
	public class UpdateBookCommandHandlerTests
	{
		private readonly Mock<IMapper> _mockMapper;
		private readonly Mock<IGenericRepository<Book>> _mockRepository;

        public UpdateBookCommandHandlerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IGenericRepository<Book>>();
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResponse_WhenRequestIsValid()
        {
            // Arrange
            var command = new UpdateBookCommandBuilder()
                .WithValidProperties()
                .Build();

            var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            result.Succeeded.Should().BeTrue();
            result.Errors.Should().BeNull();
        }
    }
}