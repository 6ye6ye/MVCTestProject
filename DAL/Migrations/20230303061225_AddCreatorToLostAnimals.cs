using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatorToLostAnimals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd40a05a-779d-41d9-991a-dd31b5a661f5"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ab0f2c94-3895-4670-96f1-ad4d1659f388"), new Guid("9a9f44bc-e5cc-4a80-8753-5762948342ab") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ab0f2c94-3895-4670-96f1-ad4d1659f388"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a9f44bc-e5cc-4a80-8753-5762948342ab"));

            migrationBuilder.RenameColumn(
                name: "AddDate",
                table: "LostAnimals",
                newName: "CreateDate");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "LostAnimals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6b0073bf-5458-4c4e-8098-5794241214b0"), "806b9e66-5507-4964-b2b5-2fef0a72a5d0", "Admin", null },
                    { new Guid("e1ed72ea-c576-47c6-bf1b-e0ba99a0178a"), "1b88e933-7695-4e24-9392-37aa1e997920", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ae8e68b6-162d-41a8-abb6-6f93dc7be00f"), 0, "692b22de-b981-4930-8efa-b070c7fb9ca3", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "e4936947-63bd-422e-b3b5-3672e07c7062", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("6b0073bf-5458-4c4e-8098-5794241214b0"), new Guid("ae8e68b6-162d-41a8-abb6-6f93dc7be00f") });

            migrationBuilder.CreateIndex(
                name: "IX_LostAnimals_CreatorId",
                table: "LostAnimals",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_LostAnimals_AspNetUsers_CreatorId",
                table: "LostAnimals",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LostAnimals_AspNetUsers_CreatorId",
                table: "LostAnimals");

            migrationBuilder.DropIndex(
                name: "IX_LostAnimals_CreatorId",
                table: "LostAnimals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1ed72ea-c576-47c6-bf1b-e0ba99a0178a"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6b0073bf-5458-4c4e-8098-5794241214b0"), new Guid("ae8e68b6-162d-41a8-abb6-6f93dc7be00f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b0073bf-5458-4c4e-8098-5794241214b0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae8e68b6-162d-41a8-abb6-6f93dc7be00f"));

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "LostAnimals");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "LostAnimals",
                newName: "AddDate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ab0f2c94-3895-4670-96f1-ad4d1659f388"), "1c321587-9d70-4df3-8538-caf6ebd2e705", "Admin", null },
                    { new Guid("bd40a05a-779d-41d9-991a-dd31b5a661f5"), "b477acde-8f3d-440f-958b-b226eec9dd68", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9a9f44bc-e5cc-4a80-8753-5762948342ab"), 0, "0532dccf-bda7-4eb1-8314-d62970d261ba", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAEGPrM0+a2DPLt2IDXeNXCxwz6N4b+aTzO0qbm2ijrTLm0wZMouCaC+8Oan/u3yF+ZQ==", null, false, "7cc15a76-40da-4574-ba60-ab71d3417b6c", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ab0f2c94-3895-4670-96f1-ad4d1659f388"), new Guid("9a9f44bc-e5cc-4a80-8753-5762948342ab") });
        }
    }
}
