using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00b8e8af-c567-4a7b-a943-97b593d48e45", null, "Employee", "EMPLOYEE" },
                    { "c07eef0b-b610-4042-bc76-8f48c76d5a32", null, "Administrator", "ADMINISTRATOR" },
                    { "f8c0628b-b2aa-4d03-ace8-c6b3f7deebf6", null, "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5d569588-f4ec-4a9a-8519-cf7318f3d24d", 0, "aa047d27-2524-4f7f-895f-985379a646f3", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHgvYydlV1DDZZLy8UF630qgA9iK693Q4eVeFIzOGnzVnEgEpugJkXyEalLui6hX3g==", null, false, "13d23904-7c5b-4990-97f4-a00caf7a0414", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c07eef0b-b610-4042-bc76-8f48c76d5a32", "5d569588-f4ec-4a9a-8519-cf7318f3d24d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00b8e8af-c567-4a7b-a943-97b593d48e45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8c0628b-b2aa-4d03-ace8-c6b3f7deebf6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c07eef0b-b610-4042-bc76-8f48c76d5a32", "5d569588-f4ec-4a9a-8519-cf7318f3d24d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c07eef0b-b610-4042-bc76-8f48c76d5a32");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d569588-f4ec-4a9a-8519-cf7318f3d24d");
        }
    }
}
