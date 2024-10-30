using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieOrganizer.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieLogs_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Category", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "Action", "R", "The Matrix" },
                    { 2, "Action", "R", "The Rock" },
                    { 3, "Action", "R", "The Terminator" },
                    { 4, "Action", "R", "Gladiator" },
                    { 5, "Action", "R", "The Departed" },
                    { 6, "Comedy", "PG", "Beetlejuice" },
                    { 7, "Comedy", "PG", "Ghostbusters" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "MovieId", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "5c3ae68e-d4aa-48d2-a26b-a349b0ebfdf2", "chris@gmail.com", false, false, null, null, "Chris", null, null, "AQAAAAIAAYagAAAAENOnBy7o5RlHeB5Jb/MtmI4uH8uvwsJmFUtdPAB+KWK0MJ3jmv3w5aOMiIePzPnc4Q==", null, false, "f830c409-58f4-475c-999b-ca16e8757455", false, null },
                    { 2, 0, "ba2fcde8-e680-4d31-a7a3-a1188e2cd708", "dan@gmail.com", false, false, null, null, "Dan", null, null, "AQAAAAIAAYagAAAAEG3PGdL3Y1HbHEpuvIEfKrQGMP70XLfqL4ZgEQfGwDPLSAb3tpCxqDFp+9mDOvqDsA==", null, false, "bbd5f7c1-9615-4a73-91f6-c30863e2166d", false, null },
                    { 3, 0, "3cf7731f-8be2-4941-93ba-119a977fe35a", "tom@gmail.com", false, false, null, null, "Tom", null, null, "AQAAAAIAAYagAAAAEBLk8mM96F56k/fn+DJzvHL8adnhASu71DlYRVT3p4Myt+rfb6q95WMY9R5xLk2hpQ==", null, false, "9edc77fd-3acc-4786-a038-c1590729f937", false, null }
                });

            migrationBuilder.InsertData(
                table: "MovieLogs",
                columns: new[] { "Id", "Comments", "MovieId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Great Action", 4, "Gladiator", 2 },
                    { 2, "Sean Connery was great", 2, "The Rock", 2 },
                    { 3, "Great Special Effects", 1, "The Matrix", 2 },
                    { 4, "Michael Keaton was hilarious", 6, "Beetlejuice", 2 },
                    { 5, "Great comedy and special effects", 7, "Ghostbusters", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieLogs_MovieId",
                table: "MovieLogs",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLogs_UserId",
                table: "MovieLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MovieId",
                table: "Users",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieLogs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
