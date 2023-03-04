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

            var libraryCards = new List<LibraryCard>
            {
                new LibraryCard
                {
                    Id = 1,
                    PersonalIdentificationNumber = 123456,
                    ExpiresOn = DateTime.Now.AddYears(1),
                    UserId = null,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                },
                new LibraryCard
                {
                    Id = 2,
                    PersonalIdentificationNumber = 123456,
                    ExpiresOn = DateTime.Now.AddYears(1),
                    UserId = null,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                },
                new LibraryCard
                {
                    Id = 3,
                    PersonalIdentificationNumber = 123456,
                    ExpiresOn = DateTime.Now.AddYears(1),
                    UserId = null,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                },
            };

            builder.HasData(libraryCards);
        }
    }
}
