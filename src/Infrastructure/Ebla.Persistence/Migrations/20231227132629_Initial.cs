using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ebla.Persistence.Migrations
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Born = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 27, 14, 26, 29, 262, DateTimeKind.Local).AddTicks(4629)),
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 27, 14, 26, 29, 264, DateTimeKind.Local).AddTicks(8613)),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Established = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 27, 14, 26, 29, 265, DateTimeKind.Local).AddTicks(2213)),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Library", x => x.Id);
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 27, 14, 26, 29, 263, DateTimeKind.Local).AddTicks(3641)),
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
                name: "BookLibrary",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    LibraryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLibrary", x => new { x.BookId, x.LibraryId });
                    table.ForeignKey(
                        name: "FK_BookLibrary_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLibrary_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
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
                columns: new[] { "Id", "Born", "Country", "Description", "Image", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1917, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", "Sir Arthur Charles Clarke CBE FRAS (16 December 1917 – 19 March 2008) was an English science fiction writer, science writer, futurist,[3] inventor, undersea explorer, and television series host.", "https://upload.wikimedia.org/wikipedia/commons/6/62/Arthur_C._Clarke_1965.jpg", null, "Arthur C. Clarke" },
                    { 2, new DateTime(1929, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Ursula Kroeber Le Guin (née Kroeber; /ˈkroʊbər lə ˈɡwɪn/ KROH-bər lə GWIN;[1] October 21, 1929 – January 22, 2018) was an American author best known for her works of speculative fiction, including science fiction works set in her Hainish universe, and the Earthsea fantasy series.", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Ursula_Le_Guin_%283551195631%29_%28cropped%29.jpg/1280px-Ursula_Le_Guin_%283551195631%29_%28cropped%29.jpg", null, "Ursula K. Le Guin" },
                    { 3, new DateTime(1975, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Brandon Winn Sanderson (born December 19, 1975) is an American author of high fantasy and science fiction. He is best known for the Cosmere fictional universe, in which most of his fantasy novels, most notably the Mistborn series and The Stormlight Archive, are set.", "https://upload.wikimedia.org/wikipedia/commons/e/ef/Brandon_Sanderson_-_Lucca_Comics_%26_Games_2016.jpg", null, "Brandon Sanderson" },
                    { 4, new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", "Adrian Czajkowski (spelt as Adrian Tchaikovsky for his books; born June 1972) is a British fantasy and science fiction author. He is best known for his series Shadows of the Apt, and for his Hugo Award-winning Children of Time series.[1]", "https://upload.wikimedia.org/wikipedia/commons/thumb/7/75/Swecon_2021_61_%28cropped%29.jpg/1280px-Swecon_2021_61_%28cropped%29.jpg", null, "Adrian Tchaikovsky" },
                    { 5, new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Stephen Edwin King (born September 21, 1947) is an American author of horror, supernatural fiction, suspense, crime, science-fiction, and fantasy novels.", "https://upload.wikimedia.org/wikipedia/commons/e/e3/Stephen_King%2C_Comicon.jpg", null, "Stephen King" },
                    { 6, new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", "John Ronald Reuel Tolkien CBE FRSL (/ˈruːl ˈtɒlkiːn/, ROOL TOL-keen;[a] 3 January 1892 – 2 September 1973) was an English writer and philologist. He was the author of the high fantasy works The Hobbit and The Lord of the Rings.", "https://upload.wikimedia.org/wikipedia/commons/d/d4/J._R._R._Tolkien%2C_ca._1925.jpg", null, "J. R. R. Tolkien" },
                    { 7, new DateTime(1928, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "William Peter Blatty (January 7, 1928 – January 12, 2017) was an American writer, director and producer.[1] He is best known for his 1971 novel, The Exorcist, and for his 1973 screenplay for the film adaptation of the same name.", "https://upload.wikimedia.org/wikipedia/commons/4/44/William-Peter-Blatty-2009.jpg", null, "William Peter Blatty" },
                    { 8, new DateTime(1975, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia", "Markus Zusak (born 23 June 1975) is an Australian writer. He is best known for The Book Thief and The Messenger, two novels which became international bestsellers. He won the Margaret A. Edwards Award in 2014.", "https://upload.wikimedia.org/wikipedia/commons/9/99/Markus_Zusak_2019_%28cropped%29.jpg", null, "Markus Zusak" },
                    { 9, new DateTime(1964, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Daniel Gerhard Brown (born June 22, 1964) is an American author best known for his thriller novels, including the Robert Langdon novels Angels & Demons (2000), The Da Vinci Code (2003), The Lost Symbol (2009), Inferno (2013), and Origin (2017).", "https://upload.wikimedia.org/wikipedia/commons/8/8b/Dan_Brown_bookjacket_cropped.jpg", null, "Dan Brown" },
                    { 10, new DateTime(1934, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "arl Edward Sagan (/ˈseɪɡən/; SAY-gən; November 9, 1934 – December 20, 1996) was an American astronomer and science communicator. His best known scientific contribution is his research on the possibility of extraterrestrial life, including experimental demonstration of the production of amino acids from basic chemicals by radiation.", "https://upload.wikimedia.org/wikipedia/commons/8/8d/Carl_Sagan_Planetary_Society_cropped.png", null, "Carl Sagan" },
                    { 11, new DateTime(1894, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", "Aldous Leonard Huxley (/ˈɔːldəs/ AWL-dəs; 26 July 1894 – 22 November 1963) was an English writer and philosopher.[1][2][3][4] His bibliography spans nearly 50 books,[5][6] including novels and non-fiction works, as well as essays, narratives, and poems.", "https://upload.wikimedia.org/wikipedia/commons/e/e9/Aldous_Huxley_psychical_researcher.png", null, "Aldous Huxley" },
                    { 12, new DateTime(1972, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Andrew Taylor Weir (/wir/; born June 16, 1972) is an American novelist.[2] His 2011 novel The Martian was adapted into the 2015 film of the same name directed by Ridley Scott. He received the John W. Campbell Award for Best New Writer in 2016[3] and his 2021 novel Project Hail Mary was a finalist for the 2022 Hugo Award for Best Novel.[4]", "https://upload.wikimedia.org/wikipedia/commons/b/b8/NASA_Journey_to_Mars_and_%E2%80%9CThe_Martian%22_%28201508180048HQ%29.jpg", null, "Andy Weir" },
                    { 13, new DateTime(1907, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Robert Anson Heinlein (/ˈhaɪnlaɪn/;[2][3][4] July 7, 1907 – May 8, 1988) was an American science fiction author, aeronautical engineer, and naval officer. Sometimes called the dean of science fiction writers,[5] he was among the first to emphasize scientific accuracy in his fiction, and was thus a pioneer of the subgenre of hard science fiction.", "https://upload.wikimedia.org/wikipedia/commons/b/bf/Heinlein-face.jpg", null, "Robert A. Heinlein" },
                    { 14, new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombia", "Gabriel José de la Concordia García Márquez (Latin American Spanish: [ɡaˈβɾjel ɣaɾˈsi.a ˈmaɾkes] ⓘ;[a] 6 March 1927 – 17 April 2014) was a Colombian novelist, short-story writer, screenwriter, and journalist, known affectionately as Gabo ([ˈɡaβo]) or Gabito ([ɡaˈβito]) throughout Latin America. Considered one of the most significant authors of the 20th century, particularly in the Spanish language, he was awarded the 1972 Neustadt International Prize for Literature and the 1982 Nobel Prize in Literature.", "https://upload.wikimedia.org/wikipedia/commons/0/0f/Gabriel_Garcia_Marquez.jpg", null, "Gabriel García Márquez" },
                    { 15, new DateTime(1986, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Franklin Patrick Herbert Jr. (October 8, 1920 – February 11, 1986) was an American science fiction author best known for the 1965 novel Dune and its five sequels. Though he became famous for his novels, he also wrote short stories and worked as a newspaper journalist, photographer, book reviewer, ecological consultant, and lecturer.", "https://upload.wikimedia.org/wikipedia/commons/6/65/Frank_Herbert_headshot.jpg", null, "Frank Herbert" },
                    { 16, new DateTime(1899, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Ernest Miller Hemingway (/ˈɜːrnɪst ˈhɛmɪŋweɪ/; July 21, 1899 – July 2, 1961) was an American novelist, short-story writer, and journalist. His economical and understated style—which included his iceberg theory—had a strong influence on 20th-century fiction, while his adventurous lifestyle and public image brought him admiration from later generations.", "https://upload.wikimedia.org/wikipedia/commons/2/28/ErnestHemingway.jpg", null, "Ernest Hemingway" },
                    { 17, new DateTime(1949, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wales", "Kenneth Martin Follett, CBE, FRSL[1][2] (born 5 June 1949) is a Welsh author of thrillers and historical novels who has sold more than 160 million copies of his works.[3]", "https://upload.wikimedia.org/wikipedia/commons/4/4c/Ken_Follett_official.jpg", null, "Ken Follett" },
                    { 18, new DateTime(1962, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Suzanne Collins (born August 10, 1962) is an American author and television writer. She is best known as the author of the young adult dystopian book series The Hunger Games.", "https://upload.wikimedia.org/wikipedia/commons/b/b9/Suzanne_Collins_David_Shankbone_2010.jpg", null, "Suzanne Collins" },
                    { 19, new DateTime(1942, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", "Stephen William Hawking (8 January 1942 – 14 March 2018) was an English theoretical physicist, cosmologist, and author who was director of research at the Centre for Theoretical Cosmology at the University of Cambridge.[6][17][18] Between 1979 and 2009, he was the Lucasian Professor of Mathematics at Cambridge, widely viewed as one of the most prestigious academic posts in the world.[19]", "https://upload.wikimedia.org/wikipedia/commons/e/eb/Stephen_Hawking.StarChild.jpg", null, "Stephen Hawking" },
                    { 20, new DateTime(1940, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Peter Bradford Benchley (May 8, 1940 – February 11, 2006) was an American author, screenwriter, and ocean activist. He is known for his bestselling novel Jaws and co-wrote its film adaptation with Carl Gottlieb. Several more of his works were also adapted for both cinema and television, including The Deep, The Island, Beast, and White Shark.", "https://upload.wikimedia.org/wikipedia/commons/d/da/Jaws_%281974%29_back_cover_featuring_a_portrait_photograph_of_Peter_Benchley_by_Alex_Gotfryd%2C_first_edition.jpg", null, "Peter Benchley" },
                    { 21, new DateTime(1835, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Samuel Langhorne Clemens (November 30, 1835 – April 21, 1910),[1] known by the pen name Mark Twain, was an American writer, humorist, essayist, entrepreneur, publisher, and lecturer. He was praised as the greatest humorist the United States has produced,[2] and William Faulkner called him the father of American literature.", "https://upload.wikimedia.org/wikipedia/commons/0/0c/Mark_Twain_by_AF_Bradley.jpg", null, "Mark Twain" },
                    { 22, new DateTime(1775, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", "Jane Austen (/ˈɒstɪn, ˈɔːstɪn/ OST-in, AW-stin; 16 December 1775 – 18 July 1817) was an English novelist known primarily for her six novels, which implicitly interpret, critique, and comment upon the British landed gentry at the end of the 18th century. Austen's plots often explore the dependence of women on marriage for the pursuit of favourable social standing and economic security.", "https://upload.wikimedia.org/wikipedia/commons/c/cc/CassandraAusten-JaneAusten%28c.1810%29_hires.jpg", null, "Jane Austen" },
                    { 23, new DateTime(1828, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "France", "Jules Gabriel Verne (/vɜːrn/;[1][2] French: [ʒyl ɡabʁijɛl vɛʁn]; 8 February 1828 – 24 March 1905)[3] was a French novelist, poet, and playwright. His collaboration with the publisher Pierre-Jules Hetzel led to the creation of the Voyages extraordinaires,[3] a series of bestselling adventure novels including Journey to the Center of the Earth (1864), Twenty Thousand Leagues Under the Seas (1870), and Around the World in Eighty Days (1872). His novels, always well documented, are generally set in the second half of the 19th century, taking into account the technological advances of the time.", "https://upload.wikimedia.org/wikipedia/commons/4/4b/Jules_Verne_by_%C3%89tienne_Carjat.jpg", null, "Jules Verne" },
                    { 24, new DateTime(1948, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "James Oliver Rigney Jr. (October 17, 1948 – September 16, 2007), better known by his pen name Robert Jordan,[1] was an American author of epic fantasy. He is known best for his series The Wheel of Time (finished by Brandon Sanderson after Jordan's death) which comprises 14 books and a prequel novel.", "https://upload.wikimedia.org/wikipedia/commons/e/ea/Robert_Jordan.jpg", null, "Robert Jordan" },
                    { 25, new DateTime(1916, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Shirley Hardie Jackson (December 14, 1916 – August 8, 1965) was an American writer known primarily for her works of horror and mystery. Over the duration of her writing career, which spanned over two decades, she composed six novels, two memoirs, and more than 200 short stories.", "https://upload.wikimedia.org/wikipedia/en/4/43/ShirleyJack.jpg", null, "Shirley Jackson" },
                    { 26, new DateTime(1951, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "William McGuire Bryson OBE HonFRS (/ˈbraɪsən/; born 8 December 1951) is an American–British journalist and author. Bryson has written a number of nonfiction books on topics including travel, the English language, and science. Born in the United States, he has been a resident of Britain for most of his adult life, returning to the U.S. between 1995 and 2003, and holds dual American and British citizenship. He served as the chancellor of Durham University from 2005 to 2011.", "https://upload.wikimedia.org/wikipedia/commons/3/35/Neil_MacGregor%2C_Bill_Bryson%2C_Claire_Walker%2C_Huw_Edwards_%2828449155987%29_%28Bryson_cropped%29.jpg", null, "Bill Bryson" },
                    { 27, new DateTime(1954, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Jon Krakauer (born April 12, 1954) is an American writer and mountaineer. He is the author of bestselling non-fiction books—Into the Wild; Into Thin Air; Under the Banner of Heaven; and Where Men Win Glory: The Odyssey of Pat Tillman—as well as numerous magazine articles. He was a member of an ill-fated expedition to summit Mount Everest in 1996, one of the deadliest disasters in the history of climbing Everest.", "https://upload.wikimedia.org/wikipedia/commons/4/4c/Jon_Krakauer_speaking_in_2009.jpg", null, "Jon Krakauer" },
                    { 28, new DateTime(1937, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Jared Mason Diamond (born September 10, 1937) is an American scientist and author best known for his popular science books. Originally trained in biochemistry and physiology,[1] Diamond is commonly referred to as a polymath, stemming from his knowledge in many fields including anthropology, ecology, geography, and evolutionary biology.[2][3] He is a professor of geography at UCLA.", "https://upload.wikimedia.org/wikipedia/commons/8/88/JaredDiamond.jpg", null, "Jared Diamond" },
                    { 29, new DateTime(1952, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "England", "Douglas Noël Adams (11 March 1952 – 11 May 2001) was an English author, humorist, and screenwriter, best known for The Hitchhiker's Guide to the Galaxy (HHGTTG). Originally a 1978 BBC radio comedy, The Hitchhiker's Guide to the Galaxy developed into a trilogy of five books that sold more than 15 million copies in his lifetime. It was further developed into a television series, several stage plays, comics, a video game, and a 2005 feature film. Adams's contribution to UK radio is commemorated in The Radio Academy's Hall of Fame.[2]", "https://upload.wikimedia.org/wikipedia/commons/c/c0/Douglas_adams_portrait_cropped.jpg", null, "Douglas Adams" },
                    { 30, new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "India", "Eric Arthur Blair (25 June 1903 – 21 January 1950), better known by his pen name George Orwell, was an English novelist, essayist, journalist, and critic.[1] His work is characterised by lucid prose, social criticism, opposition to totalitarianism, and support of democratic socialism.[2]", "https://upload.wikimedia.org/wikipedia/commons/7/7e/George_Orwell_press_photo.jpg", null, "George Orwell" },
                    { 31, new DateTime(1928, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Philip Kindred Dick (December 16, 1928 – March 2, 1982), often referred to by his initials PKD, was an American science fiction writer.[1] He wrote 44 novels and about 121 short stories, most of which appeared in science fiction magazines during his lifetime.[2] His fiction explored varied philosophical and social questions such as the nature of reality, perception, human nature, and identity, and commonly featured characters struggling against elements such as alternate realities, illusory environments, monopolistic corporations, drug abuse, authoritarian governments, and altered states of consciousness.[3][4] He is considered one of the most important figures in 20th century science fiction.[5]", "https://upload.wikimedia.org/wikipedia/commons/2/2c/Philip_K_Dick_in_early_1960s_%28photo_by_Arthur_Knight%29_02_%28cropped%29.jpg", null, "Philip K. Dick" },
                    { 32, new DateTime(1975, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "England", "Matt Haig (born 3 July 1975) is an English author and journalist. He has written both fiction and non-fiction books for children and adults, often in the speculative fiction genre.", "https://upload.wikimedia.org/wikipedia/commons/4/49/Matt_Haig.jpeg", null, "Matt Haig" },
                    { 33, new DateTime(1969, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States", "Matthew David McConaughey (/məˈkɒnəheɪ/ mə-KON-ə-hay; born November 4, 1969) is an American actor. He had his breakout role with a supporting performance in the coming-of-age comedy Dazed and Confused (1993).[1][2][3] After a number of supporting roles, his first success as a leading man came in the legal drama A Time to Kill (1996). His career progressed with lead roles in the science fiction film Contact (1997), the historical drama Amistad (1997), and the war film U-571 (2000).", "https://upload.wikimedia.org/wikipedia/commons/b/bf/Matthew_McConaughey_2019_%2848648344772%29.jpg", null, "Matthew McConaughey" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, "Science fiction (sometimes shortened to SF or sci-fi) is a genre of speculative fiction, which typically deals with imaginative and futuristic concepts such as advanced science and technology, space exploration, time travel, parallel universes, and extraterrestrial life.", null, "Science Fiction" },
                    { 2, "Fantasy literature is literature set in an imaginary universe, often but not always without any locations, events, or people from the real world. Magic, the supernatural and magical creatures are common in many of these imaginary worlds. Fantasy literature may be directed at both children and adults.", null, "Fantasy" },
                    { 3, "Horror is a genre of fiction that is intended to disturb, frighten or scare.[1] Horror is often divided into the sub-genres of psychological horror and supernatural horror, which are in the realm of speculative fiction.", null, "Horror" },
                    { 4, "Historical fiction is a literary genre in which a fictional plot takes place in the setting of particular real historical events. Although the term is commonly used as a synonym for historical fiction literature, it can also be applied to other types of narrative, including theatre, opera, cinema, and television, as well as video games and graphic novels.", null, "Historical" },
                    { 5, "Mystery is a fiction genre where the nature of an event, usually a murder or other crime, remains mysterious until the end of the story.[1] Often within a closed circle of suspects, each suspect is usually provided with a credible motive and a reasonable opportunity for committing the crime.", null, "Mystery" },
                    { 6, "Popular science (also called pop-science or popsci) is an interpretation of science intended for a general audience. While science journalism focuses on recent scientific developments, popular science is more broad ranging. It may be written by professional science journalists or by scientists themselves. It is presented in many forms, including books, film and television documentaries, magazine articles, and web pages.", null, "Popular science" },
                    { 7, "Magic realism or magical realism is a style of literary fiction and art. It paints a realistic view of the world while also adding magical elements, often blurring the lines between fantasy and reality.[1] Magic realism often refers to literature in particular, with magical or supernatural phenomena presented in an otherwise real-world or mundane setting, commonly found in novels and dramatic performances.", null, "Magic realism" },
                    { 8, "Literary fiction, mainstream fiction, non-genre fiction, serious fiction,[1] high literature,[2] artistic literature,[2] and sometimes just literature[2] are labels that, in the book trade, refer to market novels that do not fit neatly into an established genre (see genre fiction); or, otherwise, refer to novels that are character-driven rather than plot-driven, examine the human condition, use language in an experimental or poetic fashion, or are simply considered serious art.", null, "Literary" },
                    { 9, "Adventure fiction is a type of fiction that usually presents danger, or gives the reader a sense of excitement. Some adventure fiction also satisfies the literary definition of romance fiction.", null, "Adventure" },
                    { 10, "Non-fiction (or nonfiction) is any document or media content that attempts, in good faith, to convey information only about the real world, rather than being grounded in imagination.[1] Non-fiction typically aims to present topics objectively based on historical, scientific, and empirical information. However, some non-fiction ranges into more subjective territory, including sincerely held opinions on real-world topics.", null, "Non-fiction" },
                    { 11, "A romance novel or romantic novel generally refers to a type of genre fiction novel which places its primary focus on the relationship and romantic love between two people, and usually has an emotionally satisfying and optimistic ending.", null, "Romance" },
                    { 12, "Thriller is a genre of fiction with numerous, often overlapping, subgenres, including crime, horror, and detective fiction. Thrillers are characterized and defined by the moods they elicit, giving their audiences heightened feelings of suspense, excitement, surprise, anticipation and anxiety.[1] This genre is well suited to film and television.", null, "Thriller" },
                    { 13, "Political satire is a type of satire that specializes in gaining entertainment from politics. Political satire can also act as a tool for advancing political arguments in conditions where political speech and dissent are banned.", null, "Political satire" },
                    { 14, "A memoir (/ˈmɛm.wɑːr/;[1] from French mémoire [me.mwaʁ], from Latin memoria 'memory, remembrance') is any nonfiction narrative writing based on the author's personal memories.[2][3] The assertions made in the work are thus understood to be factual. While memoir has historically been defined as a subcategory of biography or autobiography since the late 20th century, the genre is differentiated in form, presenting a narrowed focus, usually a particular time phase in someone's life or career. A biography or autobiography tells the story of a life, while a memoir often tells the story of a particular career, event, or time, such as touchstone moments and turning points in the author's life. The author of a memoir may be referred to as a memoirist or a memorialist.", null, "Memoir" }
                });

            migrationBuilder.InsertData(
                table: "Library",
                columns: new[] { "Id", "Established", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1893, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Global Library" },
                    { 2, new DateTime(1922, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Obelisk Library" },
                    { 3, new DateTime(2010, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Explorer Library" },
                    { 4, new DateTime(1948, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Solitude Library" },
                    { 5, new DateTime(2015, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rainbow Library" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Country", "Description", "GenreId", "Image", "Language", "LastModified", "Pages", "Published", "Title" },
                values: new object[,]
                {
                    { 1, 1, "United Kingdom", "Rendezvous with Rama is a science fiction novel by British writer Arthur C. Clarke first published in 1973. Set in the 2130s, the story involves a 50-by-20-kilometre (31 by 12 mi) cylindrical alien starship that enters the Solar System. The story is told from the point of view of a group of human explorers who intercept the ship in an attempt to unlock its mysteries. The novel won both the Hugo[4] and Nebula[5] awards upon its release, and is regarded as one of the cornerstones in Clarke's bibliography. The concept was later extended with several sequels, written by Clarke and Gentry Lee.", 1, "https://upload.wikimedia.org/wikipedia/en/e/e1/Rama_copy.jpg", "English", null, 256, new DateTime(1973, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rendezvous with Rama" },
                    { 2, 2, "United States", "The Left Hand of Darkness is a science fiction novel by U.S. writer Ursula K. Le Guin. Published in 1969, it became immensely popular, and established Le Guin's status as a major author of science fiction.[6] The novel is set in the fictional Hainish universe as part of the Hainish Cycle, a series of novels and short stories by Le Guin, which she introduced in the 1964 short story The Dowry of Angyar. It was fourth in sequence of writing among the Hainish novels, preceded by City of Illusions, and followed by The Word for World Is Forest.[3]", 1, "https://upload.wikimedia.org/wikipedia/en/8/88/TheLeftHandOfDarkness1stEd.jpg", "English", null, 286, new DateTime(1969, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Left Hand of Darkness" },
                    { 3, 3, "United States", "The Way of Kings is an epic fantasy novel written by American author Brandon Sanderson and the first book in The Stormlight Archive series.[2] The novel was published on August 31, 2010, by Tor Books.[3] The Way of Kings consists of one prelude, one prologue, 75 chapters, an epilogue and nine interludes.[4] It was followed by Words of Radiance in 2014,[5][6][7] Oathbringer in 2017 and Rhythm of War in 2020. A leatherbound edition was released in 2021.", 2, "https://upload.wikimedia.org/wikipedia/en/8/8b/TheWayOfKings.png", "English", null, 1007, new DateTime(1969, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Way of Kings" },
                    { 4, 4, "United Kingdom", "The work was praised by Financial Times for tackling big themes—gods, messiahs, artificial intelligence, alienness—with brio.", 1, "https://upload.wikimedia.org/wikipedia/en/1/1f/Children_of_Time_%28novel%29.jpg", "English", null, 600, new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Children of Time" },
                    { 5, 5, "United Kingdom", "The Stand is a post-apocalyptic dark fantasy novel written by American author Stephen King and first published in 1978 by Doubleday. The plot centers on a deadly pandemic of weaponized influenza and its aftermath, in which the few surviving humans gather into factions that are each led by a personification of either good or evil and seem fated to clash with each other. King started writing the story in February 1975,[1] seeking to create an epic in the spirit of The Lord of the Rings. The book was difficult for him to write because of the large number of characters and storylines.", 3, "https://upload.wikimedia.org/wikipedia/commons/5/52/The_Stand_%281978%29_front_cover%2C_first_edition.png", "English", null, 1153, new DateTime(1978, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Stand" },
                    { 6, 6, "United Kingdom", "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien. It was published in 1937 to wide critical acclaim, being nominated for the Carnegie Medal and awarded a prize from the New York Herald Tribune for best juvenile fiction. The book is recognized as a classic in children's literature, and is one of the best-selling books of all time with over 100 million copies sold.", 2, "https://upload.wikimedia.org/wikipedia/en/4/4a/TheHobbit_FirstEdition.jpg", "English", null, 310, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit" },
                    { 7, 7, "United States", "The Exorcist is a 1971 horror novel written by American writer William Peter Blatty and published by Harper & Row. The book details the demonic possession of eleven-year-old Regan MacNeil, the daughter of a famous actress, and the two priests who attempt to exorcise the demon. The novel was the basis of a highly successful film adaptation released two years later, whose screenplay was also written and produced by Blatty. More movies and books were eventually added to The Exorcist franchise.", 3, "https://upload.wikimedia.org/wikipedia/en/f/fb/The_Exorcist_1971.jpg", "English", null, 340, new DateTime(1971, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Exorcist" },
                    { 8, 8, "Australia", "The Book Thief is a historical fiction novel by the Australian author Markus Zusak, set in Nazi Germany during World War II. Published in 2006, The Book Thief became an international bestseller and was translated into 63 languages and sold 17 million copies. It was adapted into the 2013 feature film, The Book Thief.", 4, "https://upload.wikimedia.org/wikipedia/en/8/8f/The_Book_Thief_by_Markus_Zusak_book_cover.jpg", "English, German", null, 584, new DateTime(2006, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Book Thief" },
                    { 9, 9, "United States", "The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown. It is Brown's second novel to include the character Robert Langdon: the first was his 2000 novel Angels & Demons. The Da Vinci Code follows symbologist Robert Langdon and cryptologist Sophie Neveu after a murder in the Louvre Museum in Paris causes them to become involved in a battle between the Priory of Sion and Opus Dei over the possibility of Jesus Christ and Mary Magdalene having had a child together.", 5, "https://upload.wikimedia.org/wikipedia/en/6/6b/DaVinciCode.jpg", "English", null, 689, new DateTime(2003, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Da Vinci Code" },
                    { 10, 10, "United States", "Cosmos is a popular science book written by astronomer and Pulitzer Prize-winning author Carl Sagan. It was published in 1980 as a companion piece to the PBS mini-series Cosmos: A Personal Voyage with which it was co-developed and intended to complement. Each of the book’s 13 illustrated chapters corresponds to one of the 13 episodes of the television series. Just a few of the ideas explored in Cosmos include the history and mutual development of science and civilization, the nature of the Universe, human and robotic space exploration, the inner workings of the cell and the DNA that controls it, and the dangers and future implications of nuclear war.", 10, "https://upload.wikimedia.org/wikipedia/en/9/91/Cosmos_book.gif", "English", null, 365, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmos" },
                    { 11, 11, "United Kingdom", "Brave New World is a dystopian novel by English author Aldous Huxley, written in 1931 and published in 1932.[2] Largely set in a futuristic World State, whose citizens are environmentally engineered into an intelligence-based social hierarchy, the novel anticipates huge scientific advancements in reproductive technology, sleep-learning, psychological manipulation and classical conditioning that are combined to make a dystopian society which is challenged by the story's protagonist.", 1, "https://upload.wikimedia.org/wikipedia/en/6/62/BraveNewWorld_FirstEdition.jpg", "English", null, 311, new DateTime(1932, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brave New World" },
                    { 12, 5, "United States", "Salem's Lot is a 1975 horror novel by American author Stephen King. It was his second published novel. The story involves a writer named Ben Mears who returns to the town of Jerusalem's Lot (or 'Salem's Lot for short) in Maine, where he lived from the age of five through nine, only to discover that the residents are becoming vampires.", 3, "https://upload.wikimedia.org/wikipedia/commons/6/61/%27Salem%27s_Lot_%281975%29_front_cover%2C_first_edition.jpg", "English", null, 439, new DateTime(1975, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salem's Lot" },
                    { 13, 12, "United States", "rtemis is a 2017 science fiction novel written by Andy Weir.[1] It takes place in the late 2080s in Artemis, the first and so far only city on the Moon. It follows the life of porter and smuggler Jasmine Jazz Bashara as she gets caught up in a conspiracy for control of the city.", 1, "https://upload.wikimedia.org/wikipedia/en/6/68/Artemis-Andy_Weir_%282017%29.jpg", "English", null, 309, new DateTime(2017, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artemis" },
                    { 14, 13, "United States", "Starship Troopers is a military science fiction novel by American writer Robert A. Heinlein. Written in a few weeks in reaction to the US suspending nuclear tests,[5] the story was first published as a two-part serial in The Magazine of Fantasy & Science Fiction as Starship Soldier, and published as a book by G. P. Putnam's Sons on November 5, 1959.", 1, "https://upload.wikimedia.org/wikipedia/en/a/a9/Starship_Troopers_%28novel%29.jpg", "English", null, 263, new DateTime(1959, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Starship Troopers" },
                    { 15, 14, "Argentina", "One Hundred Years of Solitude (Spanish: Cien años de soledad, Latin American Spanish: [sjen ˈaɲos ðe soleˈðað]) is a 1967 novel by Colombian author Gabriel García Márquez that tells the multi-generational story of the Buendía family, whose patriarch, José Arcadio Buendía, founded the fictitious town of Macondo. The novel is often cited as one of the supreme achievements in world literature.", 7, "https://upload.wikimedia.org/wikipedia/en/a/a0/Cien_a%C3%B1os_de_soledad_%28book_cover%2C_1967%29.jpg", "Spanish", null, 422, new DateTime(1967, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "One Hundred Years of Solitude" },
                    { 16, 15, "United States", "Dune is a 1965 epic science fiction novel by American author Frank Herbert, originally published as two separate serials in Analog magazine. It tied with Roger Zelazny's This Immortal for the Hugo Award in 1966 and it won the inaugural Nebula Award for Best Novel. It is the first installment of the Dune Chronicles. It is one of the world's best-selling science fiction novels.", 1, "https://upload.wikimedia.org/wikipedia/en/d/de/Dune-Frank_Herbert_%281965%29_First_edition.jpg", "English", null, 896, new DateTime(1965, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dune" },
                    { 17, 16, "United States", "The Old Man and the Sea is a 1952 novella written by the American author Ernest Hemingway. Written between December 1950 and February 1951, it tells the story of Santiago, an aging fisherman who catches a giant marlin after a long struggle, but then loses his bounty to sharks. The novella was highly anticipated and was released to record sales; the initial critical reception was equally positive, but attitudes have varied significantly since then.", 8, "https://upload.wikimedia.org/wikipedia/en/7/73/Oldmansea.jpg", "English", null, 112, new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Old Man and the Sea" },
                    { 18, 17, "United Kingdom", "The Pillars of the Earth is a historical novel by British author Ken Follett published in 1989 about the building of a cathedral in the fictional town of Kingsbridge, England. Set in the 12th century, the novel covers the time between the sinking of the White Ship and the murder of Thomas Becket, but focuses primarily on the Anarchy. The book traces the development of Gothic architecture out of the preceding Romanesque architecture, and the fortunes of the Kingsbridge priory and village against the backdrop of historical events of the time.", 4, "https://upload.wikimedia.org/wikipedia/en/b/b3/PillarsOfTheEarth.jpg", "English", null, 806, new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Pillars of the Earth" },
                    { 19, 18, "United States", "Mockingjay is a 2010 dystopian young adult fiction novel by American author Suzanne Collins. It is chronologically the last installment of The Hunger Games series, following 2008's The Hunger Games and 2009's Catching Fire. The book continues the story of Katniss Everdeen, who agrees to unify the districts of Panem in a rebellion against the tyrannical Capitol.", 9, "https://upload.wikimedia.org/wikipedia/en/c/cc/Mockingjay.JPG", "English", null, 390, new DateTime(2010, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mockingjay" },
                    { 20, 19, "United Kingdom", "A Brief History of Time: From the Big Bang to Black Holes is a book on theoretical cosmology by English physicist Stephen Hawking. It was first published in 1988. Hawking wrote the book for readers who had no prior knowledge of physics.", 10, "https://upload.wikimedia.org/wikipedia/en/a/a3/BriefHistoryTime.jpg", "English", null, 256, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Brief History of Time" },
                    { 21, 20, "United States", "Jaws is a novel by American writer Peter Benchley, published in 1974. It tells the story of a large great white shark that preys upon a small Long Island resort town and the three men who attempt to kill it. The novel grew out of Benchley's interest in shark attacks after he learned about the exploits of Montauk, New York shark fisherman Frank Mundus in 1964. Doubleday commissioned him to write the novel in 1971, a period when Benchley worked as a freelance journalist.", 12, "https://upload.wikimedia.org/wikipedia/commons/5/5f/Jaws_%281974%29_front_cover%2C_first_edition.jpg", "English", null, 278, new DateTime(1974, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaws" },
                    { 22, 21, "United States", "Adventures of Huckleberry Finn is a novel by American author Mark Twain, which was first published in the United Kingdom in December 1884 and in the United States in February 1885.", 9, "https://upload.wikimedia.org/wikipedia/commons/6/61/Huckleberry_Finn_book.JPG", "English", null, 362, new DateTime(1884, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adventures of Huckleberry Finn" },
                    { 23, 22, "United Kingdom", "Pride and Prejudice is an 1813 novel of manners by English author Jane Austen. The novel follows the character development of Elizabeth Bennet, the protagonist of the book, who learns about the repercussions of hasty judgments and comes to appreciate the difference between superficial goodness and actual goodness.", 11, "https://upload.wikimedia.org/wikipedia/commons/1/17/PrideAndPrejudiceTitlePage.jpg", "English", null, 432, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pride and Prejudice" },
                    { 24, 5, "United States", "Pet Sematary is a 1983 horror novel by American writer Stephen King. The novel was nominated for a World Fantasy Award for Best Novel in 1984,[1] and adapted into two films: one in 1989 and another in 2019. In November 2013, PS Publishing released Pet Sematary in a limited 30th-anniversary edition.", 3, "https://upload.wikimedia.org/wikipedia/commons/2/24/Pet_Sematary_%281983%29_front_cover%2C_first_edition.jpg", "English", null, 374, new DateTime(1983, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pet Sematary" },
                    { 25, 23, "France", "Journey to the Center of the Earth (French: Voyage au centre de la Terre), also translated with the variant titles A Journey to the Centre of the Earth and A Journey into the Interior of the Earth, is a classic science fiction novel by Jules Verne.", 1, "https://upload.wikimedia.org/wikipedia/commons/6/67/A_Journey_to_the_Centre_of_the_Earth-1874.jpg", "French", null, 146, new DateTime(1864, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Journey to the Center of the Earth" },
                    { 26, 24, "United States", "The Eye of the World is a high fantasy novel by American writer Robert Jordan, the first book of The Wheel of Time series. It was published by Tor Books and released on 15 January 1990. The original unabridged audiobook is read by Michael Kramer and Kate Reading. A later unabridged edition is read by Rosamund Pike. Upon first publication, The Eye of the World consisted of one prologue and 53 chapters, with an additional prologue authored upon re-release. The book was a critical, and commercial success.", 2, "https://upload.wikimedia.org/wikipedia/en/0/00/WoT01_TheEyeOfTheWorld.jpg", "English", null, 782, new DateTime(1990, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Eye of the World" },
                    { 27, 25, "United States", "The Haunting of Hill House is a 1959 gothic horror novel by American author Shirley Jackson. It was a finalist for the National Book Award and has been made into two feature films and a play, and is the basis of a Netflix series.", 3, "https://upload.wikimedia.org/wikipedia/en/0/04/HauntingOfHillHouse.JPG", "English", null, 246, new DateTime(1959, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Haunting of Hill House" },
                    { 28, 26, "United Kingdom", "Bill Bryson describes himself as a reluctant traveller, but even when he stays safely at home he can't contain his curiosity about the world around him. A Short History of Nearly Everything is his quest to understand everything that has happened from the Big Bang to the rise of civilisation - how we got from there, being nothing at all, to here, being us. The ultimate eye-opening journey through time and space, revealing the world in a way most of us have never seen it before.", 10, "https://upload.wikimedia.org/wikipedia/en/e/ed/Bill_bryson_a_short_history.jpg", "English", null, 544, new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Short History of Nearly Everything" },
                    { 29, 27, "United States", "Into the Wild is a 1996 non-fiction book written by Jon Krakauer. It is an expansion of a 9,000-word article by Krakauer on Chris McCandless titled Death of an Innocent, which appeared in the January 1993 issue of Outside.", 10, "https://upload.wikimedia.org/wikipedia/en/6/63/Into_the_Wild_%28book%29_cover.png", "English", null, 224, new DateTime(1996, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Into the Wild" },
                    { 30, 28, "United States", "Guns, Germs, and Steel: The Fates of Human Societies (subtitled A Short History of Everybody for the Last 13,000 Years in Britain) is a 1997 transdisciplinary non-fiction book by the American author Jared Diamond. The book attempts to explain why Eurasian and North African civilizations have survived and conquered others, while arguing against the idea that Eurasian hegemony is due to any form of Eurasian intellectual, moral, or inherent genetic superiority. Diamond argues that the gaps in power and technology between human societies originate primarily in environmental differences, which are amplified by various positive feedback loops. When cultural or genetic differences have favored Eurasians (for example, written language or the development among Eurasians of resistance to endemic diseases), he asserts that these advantages occurred because of the influence of geography on societies and cultures (for example, by facilitating commerce and trade between different cultures) and were not inherent in the Eurasian genomes.", 10, "https://upload.wikimedia.org/wikipedia/en/f/fc/Ggas_human_soc.jpg", "English", null, 480, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guns, Germs, and Steel" },
                    { 31, 29, "United Kingdom", "The Hitchhiker's Guide to the Galaxy is the first book in the Hitchhiker's Guide to the Galaxy comedy science fiction trilogy of five books by Douglas Adams, with a sixth book written by Eoin Colfer. The novel is an adaptation of the first four parts of Adams's radio series of the same name, centering on the adventures of the only man to survive the destruction of Earth; while roaming outer space, he comes to learn the truth behind Earth's existence. The novel was first published in London on 12 October 1979.[2] It sold 250,000 copies in the first three months.[3]", 1, "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "English", null, 208, new DateTime(1979, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hitchhiker's Guide to the Galaxy" },
                    { 32, 30, "United Kingdom", "Nineteen Eighty-Four (also published as 1984) is a dystopian novel and cautionary tale by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the authoritarian state in the novel on the Soviet Union in the era of Stalinism, and Nazi Germany.[4] More broadly, the novel examines the role of truth and facts within societies and the ways in which they can be manipulated.", 1, "https://upload.wikimedia.org/wikipedia/en/5/51/1984_first_edition_cover.jpg", "English", null, 328, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984" },
                    { 33, 31, "United States", "Do Androids Dream of Electric Sheep? (retrospectively titled Blade Runner: Do Androids Dream of Electric Sheep? in some later printings) is a 1968 dystopian science fiction novel by American writer Philip K. Dick. It is set in a post-apocalyptic San Francisco, where Earth's life has been greatly damaged by a nuclear global war, leaving most animal species endangered or extinct. The main plot follows Rick Deckard, a bounty hunter who has to retire (i.e. kill) six escaped Nexus-6 model androids, while a secondary plot follows John Isidore, a man of sub-par IQ who aids the fugitive androids.", 1, "https://upload.wikimedia.org/wikipedia/en/e/ee/DoAndroidsDream.png", "English", null, 210, new DateTime(1968, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do Androids Dream of Electric Sheep?" },
                    { 34, 1, "United States", "2001: A Space Odyssey is a 1968 science fiction novel by British writer Arthur C. Clarke. It was developed concurrently with Stanley Kubrick's film version and published after the release of the film. Clarke and Kubrick worked on the book together, but eventually only Clarke ended up as the official author. The story is based in part on various short stories by Clarke, including The Sentinel (written in 1948 for a BBC competition, but first published in 1951 under the title Sentinel of Eternity). By 1992, the novel had sold three million copies worldwide.[1] An elaboration of Clarke and Kubrick's collaborative work on this project was made in the 1972 book The Lost Worlds of 2001.", 1, "https://upload.wikimedia.org/wikipedia/en/7/77/2001_A_Space_Odyssey-Arthur_C._Clarke.jpg", "English", null, 221, new DateTime(1968, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2001: A Space Odyssey" },
                    { 35, 1, "United Kingdom", "Childhood's End is a 1953 science fiction novel by the British author Arthur C. Clarke. The story follows the peaceful alien invasion[1] of Earth by the mysterious Overlords, whose arrival begins decades of apparent utopia under indirect alien rule, at the cost of human identity and culture.", 1, "https://upload.wikimedia.org/wikipedia/en/7/72/ChildhoodsEnd%281stEd%29.jpg", "English", null, 214, new DateTime(1953, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Childhood's End" },
                    { 36, 6, "United Kingdom", "The Lord of the Rings is an epic[1] high fantasy novel[a] by the English author and scholar J. R. R. Tolkien. Set in Middle-earth, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.[2]", 2, "https://upload.wikimedia.org/wikipedia/en/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif", "English", null, 1178, new DateTime(1954, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Lord of the Rings" },
                    { 37, 30, "United Kingdom", "Animal Farm is a beast fable,[1] in the form of a satirical allegorical novella, by George Orwell, first published in England on 17 August 1945.[2][3] It tells the story of a group of anthropomorphic farm animals who rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy. Ultimately, the rebellion is betrayed and, under the dictatorship of a pig named Napoleon, the farm ends up in a state as bad as it was before.", 13, "https://upload.wikimedia.org/wikipedia/commons/f/fb/Animal_Farm_-_1st_edition.jpg", "English", null, 92, new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Animal Farm" },
                    { 38, 12, "United States", "Project Hail Mary is a 2021 science fiction novel by American novelist Andy Weir. Set in the near future, it centers on junior high (middle) school-teacher-turned-astronaut Ryland Grace, who wakes up from a coma afflicted with amnesia. He gradually remembers that he was sent to the Tau Ceti solar system, 12 light-years from Earth, to find a means of reversing a solar dimming event that could cause the extinction of humanity.[1]", 1, "https://upload.wikimedia.org/wikipedia/en/a/ad/Project_Hail_Mary%2C_First_Edition_Cover_%282021%29.jpg", "English", null, 496, new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Project Hail Mary" },
                    { 39, 32, "United Kingdom", "The Midnight Library is a fantasy novel by Matt Haig, published on 13 August 2020 by Canongate Books.[1] It was abridged and broadcast on BBC Radio 4 over ten episodes in December 2020.[2] The novel follows a 35-year-old British woman unhappy in her dead-end life who is given the opportunity to experience lives she might have had if she had made different choices.", 2, "https://upload.wikimedia.org/wikipedia/en/8/87/The_Midnight_Library.jpg", "English", null, 288, new DateTime(2020, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Midnight Library" },
                    { 40, 33, "United States", "Greenlights is a 2020 book by American actor Matthew McConaughey.[1][2] It was published on October 20, 2020, by the Crown imprint of Crown Publishing Group.[3][4]", 14, "https://upload.wikimedia.org/wikipedia/en/9/96/Greenlights_%28Matthew_McConaughey%29.png", "English", null, 304, new DateTime(2020, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greenlights" }
                });

            migrationBuilder.InsertData(
                table: "BookLibrary",
                columns: new[] { "BookId", "LibraryId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 2 },
                    { 12, 2 },
                    { 13, 2 },
                    { 14, 2 },
                    { 15, 2 },
                    { 16, 3 },
                    { 17, 3 },
                    { 18, 3 },
                    { 19, 3 },
                    { 20, 3 },
                    { 21, 4 },
                    { 22, 4 },
                    { 23, 4 },
                    { 24, 5 },
                    { 25, 5 }
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
                name: "IX_BookLibrary_LibraryId",
                table: "BookLibrary",
                column: "LibraryId");

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
                name: "BookLibrary");

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
                name: "Library");

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
