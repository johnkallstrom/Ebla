using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebla.Infrastructure.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Created).HasColumnName("Created");
            builder.Property(x => x.BookId).HasColumnName("BookId");

            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    Id = 1,
                    Created = DateTime.Now,
                    BookId = 3
                },
            };

            builder.HasData(reservations);
        }
    }
}