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
            builder.Property(x => x.ImageLink).HasColumnName("ImageLink");
            builder.Property(x => x.Wikipedia).HasColumnName("Wikipedia");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");
            builder.Property(x => x.AuthorId).HasColumnName("AuthorId");
            builder.Property(x => x.GenreId).HasColumnName("GenreId");

            var books = FileManager.ParseJsonFileToList<Book>("books.json");

            foreach (var book in books)
            {
                book.CreatedOn = DateTime.Now;
            }

            builder.HasData(books);
        }
    }
}