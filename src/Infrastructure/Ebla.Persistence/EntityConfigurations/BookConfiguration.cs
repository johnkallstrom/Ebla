namespace Ebla.Persistence.EntityConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Title).HasMaxLength(200).HasColumnName("Title");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Pages).HasColumnName("Pages");
            builder.Property(x => x.Published).HasColumnName("Published");
            builder.Property(x => x.Country).HasColumnName("Country");
            builder.Property(x => x.Image).HasColumnName("Image");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.LastModified).HasColumnName("LastModified");

            builder.HasOne(b => b.Author).WithMany(a => a.Books).IsRequired();
            builder.HasOne(b => b.Genre).WithMany(g => g.Books).IsRequired();

            var books = FileManager.ParseJsonFileToList<Book>("books.json");

            builder.HasData(books);
        }
    }
}