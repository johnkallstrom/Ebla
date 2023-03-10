using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ebla.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalIdentificationNumber = table.Column<int>(type: "int", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Returned = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loan_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Birthday", "CreatedOn", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1917, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7412), null, "Arthur C. Clarke" },
                    { 2, new DateTime(1920, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7473), null, "Isaac Asimov" },
                    { 3, new DateTime(1929, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7477), null, "Ursula K. Le Guin" },
                    { 4, new DateTime(1975, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7479), null, "Brandon Sanderson" },
                    { 5, new DateTime(1972, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7482), null, "Adrian Tchaikovsky" },
                    { 6, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7486), null, "Stephen King" },
                    { 7, new DateTime(1948, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7488), null, "Dan Simmons" },
                    { 8, new DateTime(1907, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7491), null, "Robert A. Heinlein" },
                    { 9, new DateTime(1928, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7493), null, "Philip K. Dick" },
                    { 10, new DateTime(1890, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(7496), null, "H. P. Lovecraft" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "CreatedOn", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(9627), null, "Science Fiction" },
                    { 2, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(9638), null, "Fantasy" },
                    { 3, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(9641), null, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "LibraryCard",
                columns: new[] { "Id", "CreatedOn", "ExpiresOn", "LastModified", "PersonalIdentificationNumber", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(481), new DateTime(2024, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(468), null, 123456, null },
                    { 2, new DateTime(2023, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(487), new DateTime(2024, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(486), null, 123456, null },
                    { 3, new DateTime(2023, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(491), new DateTime(2024, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(490), null, 123456, null }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "Description", "GenreId", "Language", "LastModified", "Pages", "Published", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8678), null, 1, "English", null, 256, new DateTime(1973, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rendezvous with Rama" },
                    { 2, 2, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8693), null, 1, "English", null, 255, new DateTime(1942, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Foundation" },
                    { 3, 3, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8697), null, 1, "English", null, 286, new DateTime(1969, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Left Hand of Darkness" },
                    { 4, 4, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8700), null, 2, "English", null, 738, new DateTime(2006, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Final Empire" },
                    { 5, 4, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8704), null, 2, "English", null, 738, new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Well of Ascension" },
                    { 6, 5, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8708), null, 1, "English", null, 600, new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Children of Time" },
                    { 7, 6, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8711), null, 2, "English", null, 1153, new DateTime(1978, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Stand" },
                    { 8, 6, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8744), null, 3, "English", null, 374, new DateTime(1983, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pet Sematary" },
                    { 9, 7, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8748), null, 1, "English", null, 482, new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hyperion" },
                    { 10, 8, new DateTime(2023, 3, 5, 15, 1, 21, 595, DateTimeKind.Local).AddTicks(8753), null, 1, "English", null, 382, new DateTime(1966, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Moon Is a Harsh Mistress" }
                });

            migrationBuilder.InsertData(
                table: "Loan",
                columns: new[] { "Id", "BookId", "CreatedOn", "DueDate", "LastModified", "Returned", "UserId" },
                values: new object[] { 1, 1, new DateTime(2023, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(1562), new DateTime(2023, 4, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(1549), null, null, null });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CreatedOn", "ExpiresOn", "LastModified", "UserId" },
                values: new object[] { 1, 3, new DateTime(2023, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(2574), new DateTime(2023, 3, 19, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(2561), null, null });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "BookId", "CreatedOn", "LastModified", "Rating", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2023, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(3587), null, 4, "Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem. Vivamus magna justo, lacinia eget consectetur sed, convallis at tellus. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Pellentesque in ipsum id orci porta dapibus. Curabitur aliquet quam id dui posuere blandit.", null },
                    { 2, 10, new DateTime(2023, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(3602), null, 3, "Proin eget tortor risus. Praesent sapien massa, convallis a pellentesque nec, egestas non nisi. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Mauris blandit aliquet elit, eget tincidunt nibh pulvinar a. Sed porttitor lectus nibh.", null },
                    { 3, 1, new DateTime(2023, 3, 5, 15, 1, 21, 596, DateTimeKind.Local).AddTicks(3605), null, 4, "Curabitur arcu erat, accumsan id imperdiet et, porttitor at sem. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec velit neque, auctor sit amet aliquam vel, ullamcorper sit amet ligula. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec sollicitudin molestie malesuada. Nulla porttitor accumsan tincidunt.", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreId",
                table: "Book",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_BookId",
                table: "Loan",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BookId",
                table: "Reservation",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookId",
                table: "Review",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibraryCard");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
