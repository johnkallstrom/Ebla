namespace Ebla.Infrastructure.Persistence.EntityConfigurations
{
    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.ToTable("Library");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Address).HasColumnName("Address");
            builder.Property(x => x.Country).HasColumnName("Country");
            builder.Property(x => x.Established).HasColumnName("Established");
            builder.Property(x => x.Website).HasColumnName("Website");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");

            var libraries = new List<Library>
            {
                new Library
                {
                    Id = 1,
                    Name = "Sample Library One",
                    Address = "Sample Street 1",
                    Country = "Sweden",
                    Website = "www.samplelibraryone.com",
                    Established = new DateTime(1977, 05, 01),
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                }
            };

            builder.HasData(libraries);
        }
    }
}
