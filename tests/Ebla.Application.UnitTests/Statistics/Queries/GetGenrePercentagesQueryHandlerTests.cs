namespace Ebla.Application.UnitTests.Statistics.Queries
{
    public class GetGenrePercentagesQueryHandlerTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IGenericRepository<Genre>> _mockRepository;

        public GetGenrePercentagesQueryHandlerTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockRepository = new Mock<IGenericRepository<Genre>>();
        }

        [Fact]
        public async Task Handle_Should_InvokeGetAllAsyncOnce()
        {
            // Arrange
            SetupMocks();

            var request = new GetGenrePercentagesQuery { Count = 5 };
            var handler = new GetGenrePercentagesQueryHandler(_mockRepository.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            _mockRepository.Verify(x => x.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_InvokeGetTotalBooksAsyncOnce()
        {
            // Arrange
            SetupMocks();

            var request = new GetGenrePercentagesQuery { Count = 5 };
            var handler = new GetGenrePercentagesQueryHandler(_mockRepository.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            _mockBookRepository.Verify(x => x.GetTotalBooksAsync(), Times.Once);
        }

        #region Helpers
        private void SetupMocks()
        {
            var genres = new List<Genre>
            {
                new Genre
                {
                    Id = 1,
                    Name = "Science Fiction",
                    Description = "Science fiction (sometimes shortened to SF or sci-fi) is a genre of speculative fiction, which typically deals with imaginative and futuristic concepts such as advanced science and technology, space exploration, time travel, parallel universes, and extraterrestrial life.",
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Genre
                {
                    Id = 2,
                    Name = "Fantasy",
                    Description = "Fantasy literature is literature set in an imaginary universe, often but not always without any locations, events, or people from the real world. Magic, the supernatural and magical creatures are common in many of these imaginary worlds. Fantasy literature may be directed at both children and adults.",
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Genre
                {
                    Id = 3,
                    Name = "Horror",
                    Description = "Horror is a genre of fiction that is intended to disturb, frighten or scare.[1] Horror is often divided into the sub-genres of psychological horror and supernatural horror, which are in the realm of speculative fiction.",
                    CreatedOn = DateTime.Now,
                    LastModified = null
                }
            };

            _mockBookRepository.Setup(x => x.GetTotalBooksAsync()).ReturnsAsync(40);
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(genres);
        }
        #endregion
    }
}