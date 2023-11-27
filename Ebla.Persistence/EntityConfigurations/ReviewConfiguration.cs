namespace Ebla.Persistence.EntityConfigurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Text).HasColumnName("Text");
            builder.Property(x => x.Rating).HasColumnName("Rating");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");
            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.UserId).HasColumnName("UserId");
        }
    }
}
