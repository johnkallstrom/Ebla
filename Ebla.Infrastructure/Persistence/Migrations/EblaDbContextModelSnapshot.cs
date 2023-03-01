﻿// <auto-generated />
using System;
using Ebla.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ebla.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(EblaDbContext))]
    partial class EblaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ebla.Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("Birthday");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModified");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Author", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new DateTime(1917, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1439),
                            Name = "Arthur C. Clarke"
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new DateTime(1920, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1498),
                            Name = "Isaac Asimov"
                        },
                        new
                        {
                            Id = 3,
                            Birthday = new DateTime(1929, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1501),
                            Name = "Ursula K. Le Guin"
                        },
                        new
                        {
                            Id = 4,
                            Birthday = new DateTime(1975, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1503),
                            Name = "Brandon Sanderson"
                        },
                        new
                        {
                            Id = 5,
                            Birthday = new DateTime(1972, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1506),
                            Name = "Adrian Tchaikovsky"
                        },
                        new
                        {
                            Id = 6,
                            Birthday = new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1509),
                            Name = "Stephen King"
                        },
                        new
                        {
                            Id = 7,
                            Birthday = new DateTime(1948, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1512),
                            Name = "Dan Simmons"
                        },
                        new
                        {
                            Id = 8,
                            Birthday = new DateTime(1907, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1514),
                            Name = "Robert A. Heinlein"
                        },
                        new
                        {
                            Id = 9,
                            Birthday = new DateTime(1928, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1516),
                            Name = "Philip K. Dick"
                        },
                        new
                        {
                            Id = 10,
                            Birthday = new DateTime(1890, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(1519),
                            Name = "H. P. Lovecraft"
                        });
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("AuthorId");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("GenreId");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit")
                        .HasColumnName("IsReserved");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModified");

                    b.Property<int>("Pages")
                        .HasColumnType("int")
                        .HasColumnName("Pages");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime2")
                        .HasColumnName("Published");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("Book", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2643),
                            GenreId = 1,
                            IsReserved = false,
                            Language = "English",
                            Pages = 256,
                            Published = new DateTime(1973, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Rendezvous with Rama"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2659),
                            GenreId = 1,
                            IsReserved = false,
                            Language = "English",
                            Pages = 255,
                            Published = new DateTime(1942, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Foundation"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2662),
                            GenreId = 1,
                            IsReserved = true,
                            Language = "English",
                            Pages = 286,
                            Published = new DateTime(1969, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Left Hand of Darkness"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2665),
                            GenreId = 2,
                            IsReserved = false,
                            Language = "English",
                            Pages = 738,
                            Published = new DateTime(2006, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Final Empire"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 4,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2667),
                            GenreId = 2,
                            IsReserved = false,
                            Language = "English",
                            Pages = 738,
                            Published = new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Well of Ascension"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 4,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2671),
                            GenreId = 2,
                            IsReserved = false,
                            Language = "English",
                            Pages = 600,
                            Published = new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Children of Time"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 6,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2674),
                            GenreId = 2,
                            IsReserved = false,
                            Language = "English",
                            Pages = 1153,
                            Published = new DateTime(1978, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Stand"
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 6,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2677),
                            GenreId = 3,
                            IsReserved = false,
                            Language = "English",
                            Pages = 374,
                            Published = new DateTime(1983, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pet Sematary"
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 7,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2679),
                            GenreId = 1,
                            IsReserved = false,
                            Language = "English",
                            Pages = 482,
                            Published = new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hyperion"
                        },
                        new
                        {
                            Id = 10,
                            AuthorId = 8,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(2683),
                            GenreId = 1,
                            IsReserved = false,
                            Language = "English",
                            Pages = 382,
                            Published = new DateTime(1966, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Moon Is a Harsh Mistress"
                        });
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModified");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Genre", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(3584),
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(3597),
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(3599),
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("Ebla.Domain.Entities.LibraryCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2")
                        .HasColumnName("Expires");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModified");

                    b.Property<int>("PersonalIdentificationNumber")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("LibraryCard", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(4410),
                            Expires = new DateTime(2024, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(4399),
                            PersonalIdentificationNumber = 123456
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(4417),
                            Expires = new DateTime(2024, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(4416),
                            PersonalIdentificationNumber = 123456
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(4421),
                            Expires = new DateTime(2024, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(4419),
                            PersonalIdentificationNumber = 123456
                        });
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("BookId");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DueDate");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModified");

                    b.Property<DateTime?>("Returned")
                        .HasColumnType("datetime2")
                        .HasColumnName("Returned");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Loan", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(5301),
                            DueDate = new DateTime(2023, 4, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(5288)
                        });
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("BookId");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModified");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Reservation", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 3,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(6191)
                        });
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("BookId");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("LastModified");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("Rating");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Review", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 6,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(7059),
                            Rating = 4,
                            Text = "Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Pellentesque in ipsum id orci porta dapibus. Curabitur aliquet quam id dui posuere blandit."
                        },
                        new
                        {
                            Id = 2,
                            BookId = 10,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(7072),
                            Rating = 3,
                            Text = "Proin eget tortor risus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Sed porttitor lectus nibh."
                        },
                        new
                        {
                            Id = 3,
                            BookId = 1,
                            CreatedOn = new DateTime(2023, 3, 1, 10, 32, 20, 408, DateTimeKind.Local).AddTicks(7075),
                            Rating = 4,
                            Text = "Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sollicitudin molestie malesuada. Nulla porttitor accumsan tincidunt."
                        });
                });

            modelBuilder.Entity("Ebla.Infrastructure.Identity.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Ebla.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken", (string)null);
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Book", b =>
                {
                    b.HasOne("Ebla.Domain.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ebla.Domain.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Loan", b =>
                {
                    b.HasOne("Ebla.Domain.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Ebla.Domain.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Review", b =>
                {
                    b.HasOne("Ebla.Domain.Entities.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Ebla.Infrastructure.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Ebla.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Ebla.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Ebla.Infrastructure.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ebla.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Ebla.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Book", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Ebla.Domain.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
