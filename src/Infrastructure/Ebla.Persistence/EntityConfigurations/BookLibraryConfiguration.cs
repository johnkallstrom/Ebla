namespace Ebla.Persistence.EntityConfigurations
{
    public class BookLibraryConfiguration : IEntityTypeConfiguration<BookLibrary>
    {
        public void Configure(EntityTypeBuilder<BookLibrary> builder)
        {
            builder.ToTable("BookLibrary");

            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.LibraryId).HasColumnName("LibraryId");

            builder.HasKey(bl => new { bl.BookId, bl.LibraryId });
            builder.HasOne(bl => bl.Book).WithMany(b => b.BookLibraries).HasForeignKey(bl => bl.BookId);
            builder.HasOne(bl => bl.Library).WithMany(l => l.BookLibraries).HasForeignKey(bl => bl.LibraryId);

            var bookLibraryList = FileManager.ParseJsonFileToList<BookLibrary>("booklibraries.json");

            builder.HasData(bookLibraryList);
        }
    }
}
