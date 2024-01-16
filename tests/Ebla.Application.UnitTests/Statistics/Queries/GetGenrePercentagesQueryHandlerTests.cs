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
        public async Task Handle_Should_ReturnDictionaryWithKeysAsTypeStringAndValuesAsTypeDouble()
        {
            // Arrange
            SetupMocks();

            var request = new GetGenrePercentagesQuery { Count = 5 };
            var handler = new GetGenrePercentagesQueryHandler(_mockRepository.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().BeOfType<Dictionary<string, double>>();
        }

        [Fact]
        public async Task Handle_Should_ReturnDictionaryOrderedByHighestPercentage_WhenRequestIsValid()
        {
            // Arrange
            SetupMocks();

            var request = new GetGenrePercentagesQuery { Count = 5 };
            var handler = new GetGenrePercentagesQueryHandler(_mockRepository.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().BeInDescendingOrder(x => x.Value);
        }

        [Fact]
        public async Task Handle_Should_ReturnNotEmptyDictionary_WhenRequestIsValid()
        {
            // Arrange
            SetupMocks();

            var request = new GetGenrePercentagesQuery { Count = 5 };
            var handler = new GetGenrePercentagesQueryHandler(_mockRepository.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Handle_Should_ReturnEmptyDictionary_WhenRequestIsNotValid()
        {
            // Arrange
            SetupMocks();

            var request = new GetGenrePercentagesQuery { Count = 0 };
            var handler = new GetGenrePercentagesQueryHandler(_mockRepository.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().BeEmpty();
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
                    LastModified = null,
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Id = 1,
                            Title = "Rendezvous with Rama",
                            Pages = 256,
                            Language = "English",
                            Country = "United Kingdom",
                            CreatedOn = DateTime.Now,
                            AuthorId = 1,
                            GenreId = 1
                        },
                        new Book
                        {
                            Id = 4,
                            Title = "Children of Time",
                            Pages = 600,
                            Language = "English",
                            Country = "United Kingdom",
                            CreatedOn = DateTime.Now,
                            AuthorId = 4,
                            GenreId = 1
                        },
                        new Book
                        {
                            Id = 14,
                            Title = "Starship Troopers",
                            Pages = 263,
                            Language = "English",
                            Country = "United States",
                            CreatedOn = DateTime.Now,
                            AuthorId = 13,
                            GenreId = 1
                        },
                        new Book
                        {
                            Id = 13,
                            Title = "Artemis",
                            Pages = 309,
                            Language = "English",
                            Country = "United States",
                            CreatedOn = DateTime.Now,
                            AuthorId = 12,
                            GenreId = 1
                        },
                    }
                },
                new Genre
                {
                    Id = 2,
                    Name = "Fantasy",
                    Description = "Fantasy literature is literature set in an imaginary universe, often but not always without any locations, events, or people from the real world. Magic, the supernatural and magical creatures are common in many of these imaginary worlds. Fantasy literature may be directed at both children and adults.",
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Id = 6,
                            Title = "The Hobbit",
                            Pages = 310,
                            Language = "English",
                            Country = "United Kingdom",
                            CreatedOn = DateTime.Now,
                            AuthorId = 6,
                            GenreId = 2
                        },
                        new Book
                        {
                            Id = 3,
                            Title = "The Way of Kings",
                            Pages = 1007,
                            Language = "English",
                            Country = "United States",
                            CreatedOn = DateTime.Now,
                            AuthorId = 3,
                            GenreId = 2
                        },
                    }
                },
                new Genre
                {
                    Id = 3,
                    Name = "Horror",
                    Description = "Horror is a genre of fiction that is intended to disturb, frighten or scare.[1] Horror is often divided into the sub-genres of psychological horror and supernatural horror, which are in the realm of speculative fiction.",
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Id = 7,
                            Title = "The Exorcist",
                            Pages = 340,
                            Language = "English",
                            Country = "United States",
                            CreatedOn = DateTime.Now,
                            AuthorId = 7,
                            GenreId = 3
                        },
                    }
                }
            };

            _mockBookRepository.Setup(x => x.GetTotalBooksAsync()).ReturnsAsync(7);
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(genres);
        }
        #endregion
    }
}