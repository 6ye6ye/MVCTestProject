using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddToLostAnimalsAddDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6491666e-6e5a-4f18-84dc-1625e30305f6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("778e2c7a-a69b-4498-a480-f9dc87f8aad4"));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDate",
                table: "LostAnimals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01d8ccae-4a62-4870-82a9-5a5564ddc250"), "864634b5-dcd7-43c0-bce1-f9f4074ecc19", "User", null },
                    { new Guid("fc897c50-9cc2-4ba9-839d-1e71b669902a"), "b069f4ed-dd57-4046-8baf-195f5bc0d88a", "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01d8ccae-4a62-4870-82a9-5a5564ddc250"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fc897c50-9cc2-4ba9-839d-1e71b669902a"));

            migrationBuilder.DropColumn(
                name: "AddDate",
                table: "LostAnimals");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6491666e-6e5a-4f18-84dc-1625e30305f6"), "93651ce9-c68f-433d-8d9b-8ecba6edae61", "User", null },
                    { new Guid("778e2c7a-a69b-4498-a480-f9dc87f8aad4"), "66adfbf3-7d6f-4af6-9383-bc3d12207c22", "Admin", null }
                });
        }
    }
}
