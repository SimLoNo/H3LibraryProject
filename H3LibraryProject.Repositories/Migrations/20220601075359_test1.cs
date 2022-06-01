using Microsoft.EntityFrameworkCore.Migrations;

namespace H3LibraryProject.Repositories.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Title_Author_AuthorId",
                table: "Title");

            migrationBuilder.DropForeignKey(
                name: "FK_Title_Languages_LanguageId",
                table: "Title");

            migrationBuilder.DropIndex(
                name: "IX_Title_AuthorId",
                table: "Title");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loans",
                table: "Loans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loaners",
                table: "Loaners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Loans",
                newName: "Loan");

            migrationBuilder.RenameTable(
                name: "Loaners",
                newName: "Loaner");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Author",
                newName: "NationalityId");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Title",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Loaner",
                type: "nvarchar(32)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loan",
                table: "Loan",
                column: "LoanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loaner",
                table: "Loaner",
                column: "LoanerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "LanguageId");

            migrationBuilder.CreateTable(
                name: "AuthorTitle",
                columns: table => new
                {
                    AuthorsAuthorId = table.Column<int>(type: "int", nullable: false),
                    TitlesTitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorTitle", x => new { x.AuthorsAuthorId, x.TitlesTitleId });
                    table.ForeignKey(
                        name: "FK_AuthorTitle_Author_AuthorsAuthorId",
                        column: x => x.AuthorsAuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorTitle_Title_TitlesTitleId",
                        column: x => x.TitlesTitleId,
                        principalTable: "Title",
                        principalColumn: "TitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loan_LoanerId",
                table: "Loan",
                column: "LoanerId");

            migrationBuilder.CreateIndex(
                name: "IX_Loaner_LoanerTypeId",
                table: "Loaner",
                column: "LoanerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorTitle_TitlesTitleId",
                table: "AuthorTitle",
                column: "TitlesTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loan_Loaner_LoanerId",
                table: "Loan",
                column: "LoanerId",
                principalTable: "Loaner",
                principalColumn: "LoanerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loaner_LoanerTypes_LoanerTypeId",
                table: "Loaner",
                column: "LoanerTypeId",
                principalTable: "LoanerTypes",
                principalColumn: "LoanerTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Title_Language_LanguageId",
                table: "Title",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loan_Loaner_LoanerId",
                table: "Loan");

            migrationBuilder.DropForeignKey(
                name: "FK_Loaner_LoanerTypes_LoanerTypeId",
                table: "Loaner");

            migrationBuilder.DropForeignKey(
                name: "FK_Title_Language_LanguageId",
                table: "Title");

            migrationBuilder.DropTable(
                name: "AuthorTitle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loaner",
                table: "Loaner");

            migrationBuilder.DropIndex(
                name: "IX_Loaner_LoanerTypeId",
                table: "Loaner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loan",
                table: "Loan");

            migrationBuilder.DropIndex(
                name: "IX_Loan_LoanerId",
                table: "Loan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Loaner");

            migrationBuilder.RenameTable(
                name: "Loaner",
                newName: "Loaners");

            migrationBuilder.RenameTable(
                name: "Loan",
                newName: "Loans");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.RenameColumn(
                name: "NationalityId",
                table: "Author",
                newName: "Nationality");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Title",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loaners",
                table: "Loaners",
                column: "LoanerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loans",
                table: "Loans",
                column: "LoanId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_AuthorId",
                table: "Title",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Title_Author_AuthorId",
                table: "Title",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Title_Languages_LanguageId",
                table: "Title",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
