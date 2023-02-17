﻿namespace Ebla.Infrastructure.Persistence.Configurations
{
    internal class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCard>
    {
        public void Configure(EntityTypeBuilder<LibraryCard> builder)
        {
            builder.ToTable("LibraryCard");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Expires).HasColumnName("Expires");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");

            var libraryCards = new List<LibraryCard>
            {
                new LibraryCard
                {
                    Id = 1,
                    Name = "Sample Library Card One",
                    Expires = DateTime.Now.AddYears(1),
                    UserId = null,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                },
                new LibraryCard
                {
                    Id = 2,
                    Name = "Sample Library Card Two",
                    Expires = DateTime.Now.AddYears(1),
                    UserId = Guid.Empty,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                },
                new LibraryCard
                {
                    Id = 3,
                    Name = "Sample Library Card Three",
                    Expires = DateTime.Now.AddYears(1),
                    UserId = Guid.Empty,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                },
            };

            builder.HasData(libraryCards);
        }
    }
}
