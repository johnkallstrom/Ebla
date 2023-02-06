using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.Property(x => x.AuthorId).HasColumnName("AuthorId");
            builder.Property(x => x.GenreId).HasColumnName("GenreId");

            var books = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Rendezvous with Rama",
                    Pages = 256,
                    Published = new DateTime(1973, 6, 1),
                    IsReserved = false,
                    AuthorId = 1,
                    GenreId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Foundation",
                    Pages = 255,
                    Published = new DateTime(1942, 5, 1),
                    IsReserved = false,
                    AuthorId = 2,
                    GenreId = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "The Left Hand of Darkness",
                    Pages = 286,
                    Published = new DateTime(1969, 3, 1),
                    IsReserved = false,
                    AuthorId = 3,
                    GenreId = 1
                },
            };

            builder.HasData(books);
        }
    }
}