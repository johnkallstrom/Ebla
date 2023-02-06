using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebla.Infrastructure.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loan");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Created).HasColumnName("Created");
            builder.Property(x => x.DueDate).HasColumnName("DueDate");
            builder.Property(x => x.Returned).HasColumnName("Returned");
            builder.Property(x => x.BookId).HasColumnName("BookId");

            var loans = new List<Loan>
            {
                new Loan
                {
                    Id = 1,
                    Created = DateTime.Now,
                    DueDate = DateTime.Now.AddMonths(1),
                    Returned = null,
                    BookId = 1
                },
            };

            builder.HasData(loans);
        }
    }
}