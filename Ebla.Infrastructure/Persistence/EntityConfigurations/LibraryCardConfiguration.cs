namespace Ebla.Infrastructure.Persistence.Configurations
{
    internal class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCard>
    {
        public void Configure(EntityTypeBuilder<LibraryCard> builder)
        {
            builder.ToTable("LibraryCard");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ExpiresOn).HasColumnName("ExpiresOn");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");
        }
    }
}
