namespace Ebla.Persistence.EntityConfigurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loan");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.DueDate).HasColumnName("DueDate").HasDefaultValue(DateTime.Now.AddMonths(1));
            builder.Property(x => x.Returned).HasColumnName("Returned");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.LastModified).HasColumnName("LastModified");
            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.UserId).HasColumnName("UserId");

            var loans = FileManager.ParseJsonFileToList<Loan>("loans.json");

            builder.HasData(loans);
        }
    }
}