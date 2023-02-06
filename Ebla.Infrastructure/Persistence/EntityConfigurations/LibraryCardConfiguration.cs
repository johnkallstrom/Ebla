﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ebla.Infrastructure.Persistence.Configurations
{
    internal class LibraryCardConfiguration : IEntityTypeConfiguration<LibraryCard>
    {
        public void Configure(EntityTypeBuilder<LibraryCard> builder)
        {
            builder.ToTable("LibraryCard");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Expires).HasColumnName("Expires");

            var libraryCards = new List<LibraryCard>
            {
                new LibraryCard
                {
                    Id = 1,
                    Name = "Sample Library Card One",
                    Expires = DateTime.Now.AddYears(1)
                },
                new LibraryCard
                {
                    Id = 2,
                    Name = "Sample Library Card Two",
                    Expires = DateTime.Now.AddYears(1)
                },
                new LibraryCard
                {
                    Id = 3,
                    Name = "Sample Library Card Three",
                    Expires = DateTime.Now.AddYears(1)
                },
            };

            builder.HasData(libraryCards);
        }
    }
}
