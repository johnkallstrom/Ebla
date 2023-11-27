namespace Ebla.Infrastructure.Persistence.EntityConfigurations
{
    public class BookLibraryConfiguration : IEntityTypeConfiguration<BookLibrary>
    {
        public void Configure(EntityTypeBuilder<BookLibrary> builder)
        {
            builder.ToTable("BookLibrary");

            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.LibraryId).HasColumnName("LibraryId");

            builder.HasKey(x => new { x.BookId, x.LibraryId });
            builder
                .HasOne(x => x.Book)
                .WithMany(x => x.BookLibraries)
                .HasForeignKey(x => x.BookId);

            builder
                .HasOne(x => x.Library)
                .WithMany(x => x.BookLibraries)
                .HasForeignKey(x => x.LibraryId);

            var bookLibraryList = FileManager.ParseJsonFileToList<BookLibrary>("booklibraries.json");

            builder.HasData(bookLibraryList);
        }
    }
}
