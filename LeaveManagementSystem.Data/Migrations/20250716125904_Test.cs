using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d569588-f4ec-4a9a-8519-cf7318f3d24d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83d5d625-d004-427c-8bc6-a05ffea7d0af", "AQAAAAIAAYagAAAAEMJWwQzqVsj8Kcz/5dWxymExIV0kJdppbk3PLURVocAqSYu/5tmgH03XkghlBusm3A==", "9879cfaf-5b20-45fd-bb21-9978748235c9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d569588-f4ec-4a9a-8519-cf7318f3d24d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4752a646-82a5-4009-8bef-8084692043b8", "AQAAAAIAAYagAAAAEPd6jmnco1dQVUZlbevIeLDgEpGnDtGtdOCHjyZ0ptM1RrvqhThtIGGNBPYqHB4YYg==", "d4c4fa2b-5207-4f79-bb37-e19253ac7c4e" });
        }
    }
}
