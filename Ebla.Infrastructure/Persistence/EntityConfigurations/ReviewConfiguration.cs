namespace Ebla.Infrastructure.Persistence.EntityConfigurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");

            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Text).HasColumnName("Text");
            builder.Property(x => x.Rating).HasColumnName("Rating");
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(x => x.LastModified).HasColumnName("LastModified");
            builder.Property(x => x.BookId).HasColumnName("BookId");
            builder.Property(x => x.UserId).HasColumnName("UserId");

            var reviews = new List<Review>
            {
                new Review
                {
                    Id = 1,
                    Text = "Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Pellentesque in ipsum id orci porta dapibus. Curabitur aliquet quam id dui posuere blandit.",
                    Rating = 4,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    BookId = 6,
                    UserId = null
                },
                new Review
                {
                    Id = 2,
                    Text = "Proin eget tortor risus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Sed porttitor lectus nibh.",
                    Rating = 3,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    BookId = 10,
                    UserId = null
                },
                new Review
                {
                    Id = 3,
                    Text = "Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sollicitudin molestie malesuada. Nulla porttitor accumsan tincidunt.",
                    Rating = 4,
                    CreatedOn = DateTime.Now,
                    LastModified = null,
                    BookId = 1,
                    UserId = null
                },
            };

            builder.HasData(reviews);
        }
    }
}
