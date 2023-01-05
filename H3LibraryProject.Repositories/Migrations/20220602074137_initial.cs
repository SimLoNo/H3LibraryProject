using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace H3LibraryProject.Repositories.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LName = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    FName = table.Column<string>(type: "nvarchar(32)", nullable: false),
                    MName = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    BYear = table.Column<int>(type: "int", nullable: false),
                    DYear = table.Column<int>(type: "int", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    LeasePeriod = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "LoanerTypes",
                columns: table => new
                {
                    LoanerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanerTypes", x => x.LoanerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    TitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    RYear = table.Column<short>(type: "smallint", nullable: false),
                    Pages = table.Column<short>(type: "smallint", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.TitleId);
                    table.ForeignKey(
                        name: "FK_Title_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Title_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loaner",
                columns: table => new
                {
                    LoanerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanerTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(32)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaner", x => x.LoanerId);
                    table.ForeignKey(
                        name: "FK_Loaner_LoanerTypes_LoanerTypeId",
                        column: x => x.LoanerTypeId,
                        principalTable: "LoanerTypes",
                        principalColumn: "LoanerTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Home = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "TitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanerId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loan_Loaner_LoanerId",
                        column: x => x.LoanerId,
                        principalTable: "Loaner",
                        principalColumn: "LoanerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loan_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorId", "BYear", "DYear", "FName", "LName", "MName", "NationalityId" },
                values: new object[,]
                {
                    { 3, 1821, 1881, "Fjodor", "Dostoyevskij", "Mikhájlovitj", 5 },
                    { 4, 1960, null, "Elsebeth", "Egholm", null, 1 },
                    { 2, 1805, 1875, "Hans", "Andersen", "Christian", 1 },
                    { 1, 973, 1031, "Shibiku", "Murasaki", null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "LeasePeriod", "Name" },
                values: new object[,]
                {
                    { 1, (short)30, "Skønlitteratur" },
                    { 2, (short)7, "Quicklån" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LanguageId", "Name" },
                values: new object[,]
                {
                    { 2, "Engelsk" },
                    { 1, "Dansk" },
                    { 3, "Japansk" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, "Bibliotek Vest" },
                    { 2, "Bibliotek Øst" }
                });

            migrationBuilder.InsertData(
                table: "Nationality",
                columns: new[] { "NationalityId", "Name" },
                values: new object[,]
                {
                    { 1, "Danmark" },
                    { 2, "Japan" },
                    { 3, "Storbritanien" },
                    { 4, "USA" },
                    { 5, "Rusland" }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "PublisherId", "Name" },
                values: new object[,]
                {
                    { 2, "Lindhardt & Ringhoff" },
                    { 1, "Gyldendal" },
                    { 3, "People's Press" }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "TitleId", "AuthorId", "GenreId", "LanguageId", "Name", "Pages", "PublisherId", "RYear" },
                values: new object[,]
                {
                    { 2, 2, 1, 1, "Eventyr, fortalt for Børn", (short)300, 2, (short)1837 },
                    { 3, 3, 1, 1, "Forbrydelse og Straf", (short)684, 1, (short)1866 },
                    { 5, 4, 2, 1, "Den Røde Glente", (short)408, 3, (short)2022 },
                    { 4, 3, 1, 2, "Idioten", (short)843, 1, (short)1869 },
                    { 1, 1, 1, 3, "Fortællingen om Genji", (short)224, 1, (short)1021 }
                });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "MaterialId", "Home", "LocationId", "TitleId" },
                values: new object[,]
                {
                    { 3, true, 1, 2 },
                    { 4, true, 1, 3 },
                    { 5, true, 2, 3 },
                    { 1, true, 1, 1 },
                    { 2, true, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorTitle_TitlesTitleId",
                table: "AuthorTitle",
                column: "TitlesTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_LoanerId",
                table: "Loan",
                column: "LoanerId");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_MaterialId",
                table: "Loan",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Loaner_LoanerTypeId",
                table: "Loaner",
                column: "LoanerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_LocationId",
                table: "Material",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_TitleId",
                table: "Material",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_GenreId",
                table: "Title",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_LanguageId",
                table: "Title",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorTitle");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Loaner");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "LoanerTypes");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
