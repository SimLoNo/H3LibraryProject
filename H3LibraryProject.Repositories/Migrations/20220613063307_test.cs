using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace H3LibraryProject.Repositories.Migrations
{
    public partial class test : Migration
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
                    LeasePeriod = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    RYear = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
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
                    { 1, 30, "Skønlitteratur" },
                    { 2, 7, "Quicklån" },
                    { 3, 30, "Faglitteratur" },
                    { 4, 30, "Børnebøger" },
                    { 5, 30, "Krimi" },
                    { 6, 30, "Sci-Fi" },
                    { 7, 30, "Biografier" },
                    { 8, 7, "Historisk fiktion" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LanguageId", "Name" },
                values: new object[,]
                {
                    { 4, "Russisk" },
                    { 3, "Japansk" },
                    { 5, "Hebræisk" },
                    { 1, "Dansk" },
                    { 2, "Engelsk" }
                });

            migrationBuilder.InsertData(
                table: "LoanerTypes",
                columns: new[] { "LoanerTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Låner" },
                    { 2, "Ansat" }
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
                    { 3, "People's Press" },
                    { 1, "Gyldendal" },
                    { 2, "Lindhardt & Ringhoff" },
                    { 4, "Angry Robot" }
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "AuthorId", "BYear", "DYear", "FName", "LName", "MName", "NationalityId" },
                values: new object[,]
                {
                    { 16, 1828, 1910, "Lev", "Tolstoj", "Nikolajevitj", 5 },
                    { 2, 1805, 1875, "Hans", "Andersen", "Christian", 1 },
                    { 4, 1960, null, "Elsebeth", "Egholm", null, 1 },
                    { 5, 1905, 1979, "Hans", "Scherfig", null, 1 },
                    { 7, 1907, 1976, "Egon", "Mathiesen", null, 1 },
                    { 10, 1961, null, "Jesper", "Kurt-Nielsen", null, 1 },
                    { 12, 1972, null, "Camille", "Blomst", null, 1 },
                    { 13, 1984, null, "Leif", "Thomsen", "Donbæk", 1 },
                    { 19, 1943, null, "Henning", "Jensen", null, 1 },
                    { 20, 1947, null, "Jørn", "Mader", null, 1 },
                    { 22, 1949, null, "Erwin", "Neutzky-Wulff", null, 1 },
                    { 23, 1945, null, "Knud", "Holten", null, 1 },
                    { 9, 1893, 1974, "Tom", "Kristensen", null, 1 },
                    { 6, 1949, null, "Haruki", "Murakami", null, 2 },
                    { 1, 973, 1031, "Shibiku", "Murasaki", null, 2 },
                    { 25, 1952, null, "Dianna", "Gabaldon", null, 4 },
                    { 21, 1953, null, "Pablo", "Fenjves", null, 4 },
                    { 18, 1962, null, "Chuck", "Palahniuk", null, 4 },
                    { 17, 1964, null, "Bret", "Ellis", "Easton", 4 },
                    { 3, 1821, 1881, "Fjodor", "Dostoyevskij", "Mikhájlovitj", 5 },
                    { 15, 1936, 2006, "Hunter", "Thompson", "Stockton", 4 },
                    { 14, 1907, 1988, "Robert", "Heinlein", "Anson", 4 },
                    { 11, 1933, null, "Cormac", "McCarthy", null, 4 },
                    { 24, 1949, null, "Ken", "Follet", null, 3 },
                    { 8, 1965, null, "Dan", "Abnett", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Loaner",
                columns: new[] { "LoanerId", "LoanerTypeId", "Name", "Password" },
                values: new object[,]
                {
                    { 3, 1, "Flemming", "Passw0rd" },
                    { 4, 1, "Anders", "Passw0rd" },
                    { 5, 1, "Kasper", "Passw0rd" },
                    { 2, 2, "Robin", "Passw0rd" },
                    { 1, 2, "Simon", "Passw0rd" }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "TitleId", "AuthorId", "GenreId", "LanguageId", "Name", "Pages", "PublisherId", "RYear" },
                values: new object[,]
                {
                    { 45, 25, 3, 2, "Voyager", 870, 7, 1993 },
                    { 7, 4, 1, 4, "Idioten", 843, 3, 2022 },
                    { 10, 6, 6, 3, "Hard-boiled Wonderland and The End of The World", 618, 3, 1985 },
                    { 1, 1, 1, 3, "Fortællingen om Genji", 224, 1, 1021 },
                    { 50, 25, 3, 2, "Written in My Own Heart's Blood", 825, 7, 2014 },
                    { 49, 25, 3, 2, "An Echo in the Bone", 820, 7, 2009 },
                    { 48, 25, 3, 2, "A Breath of Snow and Ashes", 1157, 7, 2005 },
                    { 47, 25, 3, 2, "The Fiery Cross", 992, 7, 2001 },
                    { 46, 25, 3, 2, "Drums of Autumn", 880, 7, 1996 },
                    { 26, 16, 1, 4, "Kazakh", 212, 1, 1863 },
                    { 44, 25, 3, 2, "Dragonfly in Amber", 752, 7, 1992 },
                    { 42, 24, 3, 2, "The Evening and the Morning", 832, 5, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Title",
                columns: new[] { "TitleId", "AuthorId", "GenreId", "LanguageId", "Name", "Pages", "PublisherId", "RYear" },
                values: new object[,]
                {
                    { 31, 20, 2, 1, "Sidste tour - Mader og Leth", 256, 2, 2022 },
                    { 30, 19, 2, 1, "Henning Jensen - En Skidt Knægt", 332, 1, 2022 },
                    { 29, 19, 7, 1, "Henning Jensen - En Skidt Knægt", 332, 1, 2022 },
                    { 25, 16, 1, 1, "Hos Kosakkerne", 212, 1, 1928 },
                    { 21, 13, 3, 1, "Personskade - sådan sikrer du dig den erstatning, du har ret til", 166, 1, 2019 },
                    { 20, 12, 1, 1, "De siger man kan elske uden at få børn", 202, 1, 2003 },
                    { 17, 10, 3, 1, "Man tager en alligator eller leguan af passende størrelse", 139, 1, 2006 },
                    { 32, 20, 7, 1, "Sidste tour - Mader og Leth", 256, 2, 2022 },
                    { 16, 10, 3, 1, "Manden der ikke ville være høflig", 331, 1, 2020 },
                    { 14, 5, 3, 1, "Dammen", 108, 1, 1958 },
                    { 13, 5, 1, 1, "Det Forsømte Forår", 179, 1, 1940 },
                    { 12, 5, 1, 1, "Den Forsvundne Fuldmægtig", 183, 1, 1938 },
                    { 8, 7, 4, 1, "Aben Osvald", 48, 1, 1947 },
                    { 6, 4, 5, 1, "Den Røde Glente", 408, 3, 2022 },
                    { 5, 4, 2, 1, "Den Røde Glente", 408, 3, 2022 },
                    { 3, 3, 1, 1, "Forbrydelse og Straf", 684, 1, 1866 },
                    { 15, 9, 1, 1, "Hærværk", 430, 1, 1930 },
                    { 43, 25, 3, 2, "Outlander", 850, 7, 1991 },
                    { 34, 22, 6, 1, "Møde", 497, 5, 2018 },
                    { 36, 7, 4, 1, "Blå mand - en remse til vrøvle og glæde", 28, 1, 1956 },
                    { 41, 24, 3, 2, "A column of Fire", 804, 6, 2017 },
                    { 40, 24, 3, 2, "World Without End", 1024, 5, 2007 },
                    { 39, 24, 3, 2, "Pillars of the Earth", 806, 5, 1989 },
                    { 33, 21, 7, 2, "If I Did It", 210, 5, 2007 },
                    { 28, 18, 1, 2, "Survivor", 304, 5, 1999 },
                    { 27, 17, 1, 2, "American Psycho", 384, 5, 1991 },
                    { 24, 15, 1, 2, "Fear and Loathing in Las Vegas", 204, 3, 1972 },
                    { 35, 7, 4, 1, "Mis med de blå øjne", 120, 1, 1949 },
                    { 23, 14, 6, 2, "Starship Trooper", 275, 3, 1959 },
                    { 19, 11, 1, 2, "The Road", 287, 5, 2006 },
                    { 18, 11, 1, 2, "No Country for Old Men", 320, 5, 2005 },
                    { 11, 6, 6, 2, "Hard-boiled Wonderland and The End of The World", 400, 3, 1991 },
                    { 9, 8, 6, 2, "Embedded", 352, 4, 2011 },
                    { 4, 3, 1, 2, "Idioten", 843, 1, 1869 },
                    { 38, 23, 4, 1, "Karfunkel-Jægerne : en eventyr-roman", 85, 1, 1980 },
                    { 37, 23, 4, 1, "Kaspers rejse til de mærkelige væseners land - et eventyr for børn", 62, 1, 1969 },
                    { 22, 14, 6, 2, "The Moon Is A Harsh Mistress", 408, 3, 1966 },
                    { 2, 2, 1, 1, "Eventyr, fortalt for Børn", 300, 2, 1837 }
                });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "MaterialId", "Home", "LocationId", "TitleId" },
                values: new object[,]
                {
                    { 3, true, 1, 2 },
                    { 50, true, 2, 34 },
                    { 51, true, 2, 35 },
                    { 52, true, 1, 35 },
                    { 53, true, 2, 36 },
                    { 54, true, 1, 37 },
                    { 6, true, 2, 4 },
                    { 13, true, 2, 9 },
                    { 16, true, 1, 11 },
                    { 26, true, 1, 18 },
                    { 27, true, 2, 19 },
                    { 28, true, 1, 19 },
                    { 31, true, 2, 22 },
                    { 32, true, 2, 23 },
                    { 33, true, 2, 24 },
                    { 37, true, 2, 27 },
                    { 38, true, 1, 27 },
                    { 39, true, 2, 28 },
                    { 40, true, 2, 28 },
                    { 49, true, 1, 33 },
                    { 1, true, 1, 1 },
                    { 2, true, 2, 1 },
                    { 14, true, 1, 10 },
                    { 15, true, 2, 10 },
                    { 48, true, 1, 32 },
                    { 47, true, 2, 32 },
                    { 46, true, 2, 31 },
                    { 45, true, 2, 30 },
                    { 4, true, 1, 3 },
                    { 5, true, 2, 3 },
                    { 24, true, 2, 3 },
                    { 7, true, 1, 5 },
                    { 8, true, 1, 5 },
                    { 9, true, 1, 6 },
                    { 10, true, 2, 6 },
                    { 12, true, 2, 8 },
                    { 17, true, 1, 12 },
                    { 18, true, 1, 13 },
                    { 19, true, 1, 14 },
                    { 11, true, 1, 7 },
                    { 20, true, 1, 15 },
                    { 22, true, 1, 15 }
                });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "MaterialId", "Home", "LocationId", "TitleId" },
                values: new object[,]
                {
                    { 23, true, 2, 16 },
                    { 25, true, 2, 17 },
                    { 29, true, 1, 20 },
                    { 30, true, 2, 21 },
                    { 34, true, 1, 25 },
                    { 35, true, 2, 25 },
                    { 41, true, 2, 29 },
                    { 42, true, 1, 29 },
                    { 43, true, 2, 30 },
                    { 44, true, 1, 30 },
                    { 21, true, 2, 15 },
                    { 36, true, 1, 26 }
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
