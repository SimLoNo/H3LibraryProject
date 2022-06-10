using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace H3LibraryProject.Repositories.Migrations
{
    public partial class fredagaften : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    table.ForeignKey(
                        name: "FK_Author_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationality",
                        principalColumn: "NationalityId",
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
                name: "AuthorTitle",
                columns: table => new
                {
                    AuthorTitleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorTitle", x => x.AuthorTitleId);
                    table.ForeignKey(
                        name: "FK_AuthorTitle_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorTitle_Title_TitleId",
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
                    ReturnDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
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
                table: "Genre",
                columns: new[] { "GenreId", "LeasePeriod", "Name" },
                values: new object[,]
                {
                    { 1, (short)30, "Skønlitteratur" },
                    { 2, (short)7, "Quicklån" },
                    { 3, (short)30, "Faglitteratur" },
                    { 4, (short)30, "Børnebøger" },
                    { 5, (short)30, "Krimi" },
                    { 6, (short)30, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "Dansk" },
                    { 2, "Engelsk" },
                    { 3, "Japansk" },
                    { 4, "Russisk" },
                    { 5, "Hebræisk" }
                });

            migrationBuilder.InsertData(
                table: "LoanerTypes",
                columns: new[] { "LoanerTypeId", "Name" },
                values: new object[,]
                {
                    { 2, "Ansat" },
                    { 1, "Låner" }
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
                    { 1, "Gyldendal" },
                    { 2, "Lindhardt & Ringhoff" },
                    { 3, "People's Press" },
                    { 4, "Angry Robot" }
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorId", "BYear", "DYear", "FName", "LName", "MName", "NationalityId" },
                values: new object[,]
                {
                    { 11, 1933, null, "Cormac", "McCarthy", null, 5 },
                    { 2, 1805, 1875, "Hans", "Andersen", "Christian", 1 },
                    { 4, 1960, null, "Elsebeth", "Egholm", null, 1 },
                    { 7, 1907, 1976, "Egon", "Mathiesen", null, 1 },
                    { 9, 1907, 1976, "Tom", "Kristensen", null, 1 },
                    { 10, 1961, null, "Jesper", "Kurt-Nielsen", null, 1 },
                    { 5, 1905, 1979, "Hans", "Scherfig", null, 1 },
                    { 13, 1984, null, "Leif", "Thomsen", "Donbæk", 1 },
                    { 1, 973, 1031, "Shibiku", "Murasaki", null, 2 },
                    { 6, 1949, null, "Haruki", "Murakami", null, 2 },
                    { 8, 1965, null, "Dan", "Abnett", null, 3 },
                    { 12, 1972, null, "Camille", "Blomst", null, 1 },
                    { 3, 1821, 1881, "Fjodor", "Dostoyevskij", "Mikhájlovitj", 5 }
                });

            migrationBuilder.InsertData(
                table: "Loaner",
                columns: new[] { "LoanerId", "LoanerTypeId", "Name", "Password" },
                values: new object[,]
                {
                    { 2, 2, "Robin", "Passw0rd" },
                    { 1, 2, "Simon", "Passw0rd" },
                    { 5, 1, "Kasper", "Passw0rd" },
                    { 4, 1, "Anders", "Passw0rd" },
                    { 3, 1, "Flemming", "Passw0rd" }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "TitleId", "AuthorId", "GenreId", "LanguageId", "Name", "Pages", "PublisherId", "RYear" },
                values: new object[,]
                {
                    { 7, 4, 1, 4, "Idioten", (short)843, 3, (short)2022 },
                    { 10, 6, 6, 3, "Hard-boiled Wonderland & The End of The World", (short)618, 3, (short)1985 },
                    { 19, 11, 1, 2, "The Road", (short)287, 5, (short)2006 },
                    { 3, 3, 1, 1, "Forbrydelse og Straf", (short)684, 1, (short)1866 },
                    { 5, 4, 2, 1, "Den Røde Glente", (short)408, 3, (short)2022 },
                    { 6, 4, 5, 1, "Den Røde Glente", (short)408, 3, (short)2022 },
                    { 8, 7, 4, 1, "Aben Osvald", (short)33, 1, (short)1947 },
                    { 12, 5, 1, 1, "Den Forsvundne Fuldmægtig", (short)183, 1, (short)1938 },
                    { 13, 5, 1, 1, "Det Forsømte Forår", (short)179, 1, (short)1940 },
                    { 14, 5, 3, 1, "Dammen", (short)108, 1, (short)1958 },
                    { 1, 1, 1, 3, "Fortællingen om Genji", (short)224, 1, (short)1021 },
                    { 15, 9, 1, 1, "Hærværk", (short)430, 1, (short)1930 },
                    { 17, 10, 3, 1, "Man tager en alligator eller leguan af passende størrelse", (short)139, 1, (short)2006 },
                    { 20, 12, 1, 1, "De siger man kan elske uden at få børn", (short)202, 1, (short)2003 },
                    { 21, 13, 3, 1, "Personskade - sådan sikrer du dig den erstatning, du har ret til", (short)166, 1, (short)2019 },
                    { 4, 3, 1, 2, "Idioten", (short)843, 1, (short)1869 },
                    { 9, 8, 6, 2, "Embedded", (short)352, 4, (short)2011 },
                    { 11, 6, 6, 2, "Hard-boiled Wonderland & The End of The World", (short)400, 3, (short)1991 },
                    { 18, 11, 1, 2, "No Country for Old Men", (short)320, 5, (short)2005 },
                    { 16, 10, 3, 1, "Manden der ikke ville være høflig", (short)331, 1, (short)2020 },
                    { 2, 2, 1, 1, "Eventyr, fortalt for Børn", (short)300, 2, (short)1837 }
                });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "MaterialId", "Home", "LocationId", "TitleId" },
                values: new object[,]
                {
                    { 3, true, 1, 2 },
                    { 14, true, 1, 10 },
                    { 2, true, 2, 1 },
                    { 1, true, 1, 1 },
                    { 28, true, 1, 19 },
                    { 27, true, 2, 19 },
                    { 26, true, 1, 18 },
                    { 16, true, 1, 11 },
                    { 13, true, 2, 9 },
                    { 6, true, 2, 4 },
                    { 30, true, 2, 21 },
                    { 29, true, 1, 20 },
                    { 25, true, 2, 17 },
                    { 23, true, 2, 16 },
                    { 22, true, 1, 15 },
                    { 21, true, 2, 15 },
                    { 20, true, 1, 15 },
                    { 19, true, 1, 14 },
                    { 18, true, 1, 13 },
                    { 17, true, 1, 12 },
                    { 12, true, 2, 8 },
                    { 10, true, 2, 6 },
                    { 9, true, 1, 6 },
                    { 8, true, 1, 5 },
                    { 7, true, 1, 5 },
                    { 24, true, 2, 3 },
                    { 5, true, 2, 3 },
                    { 4, true, 1, 3 },
                    { 15, true, 2, 10 },
                    { 11, true, 1, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_NationalityId",
                table: "Author",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorTitle_AuthorId",
                table: "AuthorTitle",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorTitle_TitleId",
                table: "AuthorTitle",
                column: "TitleId");

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
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Loaner");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Nationality");

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
