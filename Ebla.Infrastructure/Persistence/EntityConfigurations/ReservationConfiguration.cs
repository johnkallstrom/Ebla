namespace Ebla.Infrastructure.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ExpiresOn).HasColumnName("ExpiresOn");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");
            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.UserId).HasColumnName("UserId");
        }
    }
}