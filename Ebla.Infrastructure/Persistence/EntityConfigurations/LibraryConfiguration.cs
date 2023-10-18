namespace Ebla.Infrastructure.Persistence.EntityConfigurations
{
    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.ToTable("Library");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Address).HasColumnName("Address");
            builder.Property(x => x.Established).HasColumnName("Established");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");

            var libraries = new List<Library>
            {
                new Library
                {
                    Id = 1,
                    Name = "Palanaeum",
                    Description = null,
                    Address = null,
                    Established = null,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                }
            };

            builder.HasData(libraries);
        }
    }
}
