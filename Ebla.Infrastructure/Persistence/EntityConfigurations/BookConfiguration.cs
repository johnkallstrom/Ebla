namespace Ebla.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Title).HasMaxLength(200).HasColumnName("Title");
            builder.Property(x => x.Pages).HasColumnName("Pages");
            builder.Property(x => x.Published).HasColumnName("Published");
            builder.Property(x => x.IsReserved).HasColumnName("IsReserved");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");
            builder.Property(x => x.AuthorId).HasColumnName("AuthorId");
            builder.Property(x => x.GenreId).HasColumnName("GenreId");

            var books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Rendezvous with Rama",
                    Description = null,
                    Pages = 256,
                    Published = new DateTime(1973, 6, 1),
                    Language = "English",
                    IsReserved = false,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 1,
                    GenreId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Foundation",
                    Description = null,
                    Pages = 255,
                    Published = new DateTime(1942, 5, 1),
                    Language = "English",
                    IsReserved = false,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 2,
                    GenreId = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "The Left Hand of Darkness",
                    Description = null,
                    Pages = 286,
                    Published = new DateTime(1969, 3, 1),
                    Language = "English",
                    IsReserved = true,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 3,
                    GenreId = 1
                },
                new Book
                {
                    Id = 4,
                    Title = "The Final Empire",
                    Description = null,
                    Pages = 738,
                    Published = new DateTime(2006, 7, 17),
                    Language = "English",
                    IsReserved = false,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 4,
                    GenreId = 2
                },
                new Book
                {
                    Id = 5,
                    Title = "The Well of Ascension",
                    Description = null,
                    Pages = 738,
                    Published = new DateTime(2007, 8, 21),
                    Language = "English",
                    IsReserved = false,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 4,
                    GenreId = 2
                },
                new Book
                {
                    Id = 6,
                    Title = "Children of Time",
                    Description = null,
                    Pages = 600,
                    Published = new DateTime(2015, 6, 1),
                    Language = "English",
                    IsReserved = false,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 4,
                    GenreId = 2
                },
                new Book
                {
                    Id = 7,
                    Title = "The Stand",
                    Description = null,
                    Pages = 1153,
                    Published = new DateTime(1978, 10, 3),
                    Language = "English",
                    IsReserved = false,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 6,
                    GenreId = 2
                },
                new Book
                {
                    Id = 8,
                    Title = "Pet Sematary",
                    Description = null,
                    Pages = 374,
                    Published = new DateTime(1983, 11, 14),
                    Language = "English",
                    IsReserved = false,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 6,
                    GenreId = 3
                },
                new Book
                {
                    Id = 9,
                    Title = "Hyperion",
                    Description = null,
                    Pages = 482,
                    Published = new DateTime(1989, 1, 1),
                    Language = "English",
                    IsReserved = false,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 7,
                    GenreId = 1
                },
                new Book
                {
                    Id = 10,
                    Title = "The Moon Is a Harsh Mistress",
                    Description = null,
                    Pages = 382,
                    Published = new DateTime(1966, 6, 2),
                    Language = "English",
                    IsReserved = false,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    AuthorId = 8,
                    GenreId = 1
                },
            };

            builder.HasData(books);
        }
    }
}