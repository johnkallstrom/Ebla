using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebla.Infrastructure.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasMaxLength(200).HasColumnName("Name");
            builder.Property(x => x.Birthday).HasColumnName("Birthday");

            var authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name = "Arthur C. Clarke",
                    Birthday = new DateTime(1917, 12, 16),
                },
                new Author
                {
                    Id = 2,
                    Name = "Isaac Asimov",
                    Birthday = new DateTime(1920, 1, 2),
                },
                new Author
                {
                    Id = 3,
                    Name = "Ursula K. Le Guin",
                    Birthday = new DateTime(1929, 10, 21),
                },
            };

            builder.HasData(authors);
        }
    }
}
