using Microsoft.EntityFrameworkCore.Migrations;

namespace H3LibraryProject.Repositories.Migrations
{
    public partial class AddedFkToLoan2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Loan_MaterialId",
                table: "Loan",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Material_MaterialId",
                table: "Loan",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Material_MaterialId",
                table: "Loan");

            migrationBuilder.DropIndex(
                name: "IX_Loan_MaterialId",
                table: "Loan");
        }
    }
}
