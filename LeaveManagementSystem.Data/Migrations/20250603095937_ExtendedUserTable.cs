using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d569588-f4ec-4a9a-8519-cf7318f3d24d",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb718d5c-2f80-4987-a77b-a2224e11c205", new DateOnly(1950, 12, 1), "Default", "Default", "AQAAAAIAAYagAAAAEFpt5RwETJO0eec/rB4j6v7wvR/BXWku2aftNju1htjrcHY1pYgOp/PHkMleUtBqjg==", "dd8d6b7f-fc55-4cc9-b6f2-3f1f8b66717a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d569588-f4ec-4a9a-8519-cf7318f3d24d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa047d27-2524-4f7f-895f-985379a646f3", "AQAAAAIAAYagAAAAEHgvYydlV1DDZZLy8UF630qgA9iK693Q4eVeFIzOGnzVnEgEpugJkXyEalLui6hX3g==", "13d23904-7c5b-4990-97f4-a00caf7a0414" });
        }
    }
}
