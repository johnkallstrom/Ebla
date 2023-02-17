namespace Ebla.Infrastructure.Persistence.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");

            var genres = new List<Genre>
            {
                new Genre
                {
                    Id = 1,
                    Name = "Science Fiction",
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                },
                new Genre
                {
                    Id = 2,
                    Name = "Fantasy",
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                },
                new Genre
                {
                    Id = 3,
                    Name = "Horror",
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                },
            };

            builder.HasData(genres);
        }
    }
}
