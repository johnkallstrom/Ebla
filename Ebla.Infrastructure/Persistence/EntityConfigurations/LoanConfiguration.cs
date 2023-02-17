namespace Ebla.Infrastructure.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loan");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.DueDate).HasColumnName("DueDate");
            builder.Property(x => x.Returned).HasColumnName("Returned");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");
            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.UserId).HasColumnName("UserId");

            var loans = new List<Loan>
            {
                new Loan
                {
                    Id = 1,
                    DueDate = DateTime.Now.AddMonths(1),
                    Returned = null,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    BookId = 1,
                    UserId = Guid.Empty,
                },
            };

            builder.HasData(loans);
        }
    }
}