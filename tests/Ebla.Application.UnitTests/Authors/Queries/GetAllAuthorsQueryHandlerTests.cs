namespace Ebla.Application.UnitTests.Authors.Queries
{
    public class GetAllAuthorsQueryHandlerTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IGenericRepository<Author>> _mockRepository;

        public GetAllAuthorsQueryHandlerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IGenericRepository<Author>>();
        }

        [Fact]
        public async Task Handle_Should_ReturnListOfAuthorSlimDto()
        {
            // Arrange
            var entities = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name = "Arthur C. Clarke",
                    Description = "Sir Arthur Charles Clarke CBE FRAS (16 December 1917 – 19 March 2008) was an English science fiction writer, science writer, futurist,[3] inventor, undersea explorer, and television series host.",
                    Born = new DateTime(1917, 12, 16),
                    Country = "United Kingdom",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/6/62/Arthur_C._Clarke_1965.jpg",
                    Books = null,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                }
            };

            var dtos = new List<AuthorSlimDto>
            {
                new AuthorSlimDto(1, "Arthur C. Clarke", new DateTime(1917, 12, 16), "United Kingdom", "https://upload.wikimedia.org/wikipedia/commons/6/62/Arthur_C._Clarke_1965.jpg")
            };

            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(entities);
            _mockMapper.Setup(x => x.Map<IEnumerable<AuthorSlimDto>>(entities)).Returns(dtos);

            var request = new GetAllAuthorsQuery();
            var handler = new GetAllAuthorsQueryHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().AllBeOfType<AuthorSlimDto>();
        }

        [Fact]
        public async Task Handle_Should_ReturnEmptyListOfAuthorSlimDto()
        {
            // Arrange
            var entities = new List<Author>();
            var dtos = new List<AuthorSlimDto>();

            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(entities);
            _mockMapper.Setup(x => x.Map<IEnumerable<AuthorSlimDto>>(entities)).Returns(dtos);

            var request = new GetAllAuthorsQuery();
            var handler = new GetAllAuthorsQueryHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().BeEmpty();
            result.Should().AllBeOfType<AuthorSlimDto>();
        }
    }
}