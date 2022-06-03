using Microsoft.EntityFrameworkCore.Migrations;

namespace H3LibraryProject.Repositories.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LoanerTypes",
                columns: new[] { "LoanerTypeId", "Name" },
                values: new object[] { 1, "Låner" });

            migrationBuilder.InsertData(
                table: "LoanerTypes",
                columns: new[] { "LoanerTypeId", "Name" },
                values: new object[] { 2, "Ansat" });

            migrationBuilder.InsertData(
                table: "Loaner",
                columns: new[] { "LoanerId", "LoanerTypeId", "Name", "Password" },
                values: new object[] { 3, 1, "Flemming", "Passw0rd" });

            migrationBuilder.InsertData(
                table: "Loaner",
                columns: new[] { "LoanerId", "LoanerTypeId", "Name", "Password" },
                values: new object[] { 1, 2, "Simon", "Passw0rd" });

            migrationBuilder.InsertData(
                table: "Loaner",
                columns: new[] { "LoanerId", "LoanerTypeId", "Name", "Password" },
                values: new object[] { 2, 2, "Robin", "Passw0rd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Loaner",
                keyColumn: "LoanerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Loaner",
                keyColumn: "LoanerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Loaner",
                keyColumn: "LoanerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LoanerTypes",
                keyColumn: "LoanerTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoanerTypes",
                keyColumn: "LoanerTypeId",
                keyValue: 2);
        }
    }
}
