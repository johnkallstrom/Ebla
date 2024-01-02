namespace Ebla.Persistence.EntityConfigurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ExpiresOn).HasColumnName("ExpiresOn").HasDefaultValue(DateTime.Now.AddDays(14));
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.LastModified).HasColumnName("LastModified");
            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.UserId).HasColumnName("UserId");

            var reservations = FileManager.ParseJsonFileToList<Reservation>("reservations.json");

            builder.HasData(reservations);
        }
    }
}