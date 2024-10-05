using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class inversePropertyForCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01d62d5d-1e17-4c30-a607-1ed8bbb3bb19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c249dda2-a17f-44a1-a451-5a583220cc40");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "213e9d8b-eb90-4b02-9b41-87b078ab7051", null, "Admin", "ADMIN" },
                    { "77b771b4-030b-4568-abd4-ad69632bfbab", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "213e9d8b-eb90-4b02-9b41-87b078ab7051");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77b771b4-030b-4568-abd4-ad69632bfbab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01d62d5d-1e17-4c30-a607-1ed8bbb3bb19", null, "User", "USER" },
                    { "c249dda2-a17f-44a1-a451-5a583220cc40", null, "Admin", "ADMIN" }
                });
        }
    }
}
