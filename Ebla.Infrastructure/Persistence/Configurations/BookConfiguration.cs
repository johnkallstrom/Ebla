using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebla.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Title).HasMaxLength(200).HasColumnName("Title");
            builder.Property(x => x.Pages).HasColumnName("Pages");
            builder.Property(x => x.Published).HasColumnName("Published");
            builder.Property(x => x.IsReserved).HasColumnName("IsReserved");
        }
    }
}
