namespace Ebla.Persistence.EntityConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.LastModified).HasColumnName("LastModified");

            var genres = FileManager.ParseJsonFileToList<Genre>("genres.json");

            builder.HasData(genres);
        }
    }
}
