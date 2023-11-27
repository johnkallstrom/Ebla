﻿namespace Ebla.Infrastructure.Persistence.EntityConfigurations
{
    public class BookLibraryConfiguration : IEntityTypeConfiguration<BookLibrary>
    {
        public void Configure(EntityTypeBuilder<BookLibrary> builder)
        {
            builder.ToTable("BookLibrary");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.LibraryId).HasColumnName("LibraryId");

            var bookLibraryList = FileManager.ParseJsonFileToList<BookLibrary>("booklibraries.json");

            foreach (var bookLibrary in bookLibraryList)
            {
                bookLibrary.CreatedOn = DateTime.Now;
            }

            builder.HasData(bookLibraryList);
        }
    }
}
