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

            var libraries = GetData();

            builder.HasData(libraries);
        }

        private List<Library> GetData()
        {
            var libraries = Enumerable.Empty<Library>();

            string path = FilePath();
            if (Path.Exists(path))
            {
                using (var sr = new StreamReader(path))
                {
                    var json = sr.ReadToEnd();
                    libraries = JsonConvert.DeserializeObject<List<Library>>(json);
                }
            }

            foreach (var library in libraries)
            {
                library.CreatedOn = DateTime.Now;
            }

            return libraries.ToList();
        }

        private string FilePath()
        {
            string fileName = "libraries.json";
            string workingDir = Directory.GetCurrentDirectory().Replace("Ebla.Api", "Ebla.Infrastructure");

            return $@"{workingDir}\Persistence\EntitySeedData\{fileName}";
        }
    }
}
