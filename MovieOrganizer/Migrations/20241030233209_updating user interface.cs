using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieOrganizer.Migrations
{
    /// <inheritdoc />
    public partial class updatinguserinterface : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff774316-9eb3-4ffc-9233-43890175f1a0", "AQAAAAIAAYagAAAAEEcogbEC9OQg3tyvNtNoL19se2uE2QR7pCdcXSVhP0rssv9PzS68urhJ4P29Y+h68w==", "95719580-999e-4814-a163-2434c9ec822e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30d31012-5c80-401e-ad34-91045579e840", "AQAAAAIAAYagAAAAEM9Ei9LbUR8SIUcyAo6Qhmp8ZT+LtuQ8k3u7rxShYmFVf+NLOCOjoiurASDhPJ1rew==", "3ea3d67f-1274-46eb-a76f-40e1370430f3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb3fb9c5-2841-4b41-9978-b125e6423eff", "AQAAAAIAAYagAAAAEJIPgiF8LKHyy56qhkkhc9B2HsaY1aqGqm5bxZBqeWG1QexOEVmgeTNWHQqWR6LsMA==", "805ec9b2-6d52-4bb6-a298-386600541692" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c3ae68e-d4aa-48d2-a26b-a349b0ebfdf2", "AQAAAAIAAYagAAAAENOnBy7o5RlHeB5Jb/MtmI4uH8uvwsJmFUtdPAB+KWK0MJ3jmv3w5aOMiIePzPnc4Q==", "f830c409-58f4-475c-999b-ca16e8757455" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba2fcde8-e680-4d31-a7a3-a1188e2cd708", "AQAAAAIAAYagAAAAEG3PGdL3Y1HbHEpuvIEfKrQGMP70XLfqL4ZgEQfGwDPLSAb3tpCxqDFp+9mDOvqDsA==", "bbd5f7c1-9615-4a73-91f6-c30863e2166d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3cf7731f-8be2-4941-93ba-119a977fe35a", "AQAAAAIAAYagAAAAEBLk8mM96F56k/fn+DJzvHL8adnhASu71DlYRVT3p4Myt+rfb6q95WMY9R5xLk2hpQ==", "9edc77fd-3acc-4786-a038-c1590729f937" });
        }
    }
}
