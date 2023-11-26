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
            builder.Property(x => x.Established).HasColumnName("Established");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");

            var libraries = FileManager.ParseJsonFileToEntityList<Library>("libraries.json");

            foreach (var library in libraries)
            {
                library.CreatedOn = DateTime.Now;
            }

            builder.HasData(libraries);
        }
    }
}
