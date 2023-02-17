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
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");

            var authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    Name = "Arthur C. Clarke",
                    Birthday = new DateTime(1917, 12, 16),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Author
                {
                    Id = 2,
                    Name = "Isaac Asimov",
                    Birthday = new DateTime(1920, 1, 2),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Author
                {
                    Id = 3,
                    Name = "Ursula K. Le Guin",
                    Birthday = new DateTime(1929, 10, 21),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Author
                {
                    Id = 4,
                    Name = "Brandon Sanderson",
                    Birthday = new DateTime(1975, 12, 19),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Author
                {
                    Id = 5,
                    Name = "Adrian Tchaikovsky",
                    Birthday = new DateTime(1972, 6, 4),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Author
                {
                    Id = 6,
                    Name = "Stephen King",
                    Birthday = new DateTime(1947, 9, 21),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Author
                {
                    Id = 7,
                    Name = "Dan Simmons",
                    Birthday = new DateTime(1948, 4, 4),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Author
                {
                    Id = 8,
                    Name = "Robert A. Heinlein",
                    Birthday = new DateTime(1907, 7, 7),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Author
                {
                    Id = 9,
                    Name = "Philip K. Dick",
                    Birthday = new DateTime(1928, 3, 2),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
                new Author
                {
                    Id = 10,
                    Name = "H. P. Lovecraft",
                    Birthday = new DateTime(1890, 8, 20),
                    CreatedOn = DateTime.Now,
                    LastModified = null
                },
            };

            builder.HasData(authors);
        }
    }
}
