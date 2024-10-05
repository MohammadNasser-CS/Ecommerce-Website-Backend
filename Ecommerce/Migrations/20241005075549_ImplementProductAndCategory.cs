using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class ImplementProductAndCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09dbe2af-c2cb-443a-ae89-0a2863ba4f9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c9690aa-fd05-418d-812d-b0e6a2900a45");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38080f2b-f9e9-4b37-a9b0-db5da89c138d", null, "Admin", "ADMIN" },
                    { "f20e5759-e0b1-42d7-8148-e29092fe3bd4", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38080f2b-f9e9-4b37-a9b0-db5da89c138d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f20e5759-e0b1-42d7-8148-e29092fe3bd4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09dbe2af-c2cb-443a-ae89-0a2863ba4f9b", null, "User", "USER" },
                    { "8c9690aa-fd05-418d-812d-b0e6a2900a45", null, "Admin", "ADMIN" }
                });
        }
    }
}
