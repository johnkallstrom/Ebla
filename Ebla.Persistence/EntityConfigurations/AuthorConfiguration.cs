namespace Ebla.Persistence.EntityConfigurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasMaxLength(200).HasColumnName("Name");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Born).HasColumnName("Born");
            builder.Property(x => x.Country).HasColumnName("Country");
            builder.Property(x => x.ImageLink).HasColumnName("ImageLink");
            builder.Property(x => x.Wikipedia).HasColumnName("Wikipedia");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");

            var authors = FileManager.ParseJsonFileToList<Author>("authors.json");

            builder.HasData(authors);
        }
    }
}
