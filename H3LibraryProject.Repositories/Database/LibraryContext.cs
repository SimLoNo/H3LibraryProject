using H3LibraryProject.Repositories.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3LibraryProject.Repositories.Database
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() { }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<Loaner> Loaner { get; set; }
        public DbSet<LoanerType> LoanerTypes { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Title> Title { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasMany(x => x.Titles)
                .WithMany(x => x.Authors)
                .UsingEntity<AuthorTitle>(
                    x => x.HasOne(x => x.Title)
                    .WithMany().HasForeignKey(x => x.TitleId),
                    x => x.HasOne(x => x.Author)
                   .WithMany().HasForeignKey(x => x.AuthorId));

            modelBuilder.Entity<LoanerType>().HasData(
               new()
               {
                   LoanerTypeId = 1,
                   Name = "Låner"
               },
               new()
               {
                   LoanerTypeId = 2,
                   Name = "Ansat"
               }
               );
            modelBuilder.Entity<Loaner>().HasData(
               new()
               {
                   LoanerId = 1,
                   Name = "Simon",
                   LoanerTypeId = 2,
                   Password = "Passw0rd"
               },
               new()
               {
                   LoanerId = 2,
                   Name = "Robin",
                   LoanerTypeId = 2,
                   Password = "Passw0rd"
               },
               new()
               {
                   LoanerId = 3,
                   Name = "Flemming",
                   LoanerTypeId = 1,
                   Password = "Passw0rd"
               },
               new()
               {
                   LoanerId = 4,
                   Name = "Anders",
                   LoanerTypeId = 1,
                   Password = "Passw0rd"
               },
               new()
               {
                   LoanerId = 5,
                   Name = "Kasper",
                   LoanerTypeId = 1,
                   Password = "Passw0rd"
               }
               );
            modelBuilder.Entity<Publisher>().HasData(
               new()
               {
                   PublisherId = 1,
                   Name = "Gyldendal"
               },
               new()
               {
                   PublisherId = 2,
                   Name = "Lindhardt & Ringhoff"
               },
               new()
               {
                   PublisherId = 3,
                   Name = "People's Press"
               },
               new()
               {
                   PublisherId = 4,
                   Name = "Angry Robot"
               }
               );
            modelBuilder.Entity<Location>().HasData(
               new()
               {
                   LocationId = 1,
                   Name = "Bibliotek Vest"
               },
               new()
               {
                   LocationId = 2,
                   Name = "Bibliotek Øst"
               }
               );
            modelBuilder.Entity<Language>().HasData(
               new()
               {
                   LanguageId = 1,
                   Name = "Dansk"
               },
               new()
               {
                   LanguageId = 2,
                   Name = "Engelsk"
               },
                new()
                {
                    LanguageId = 3,
                    Name = "Japansk"
                }
               );
            modelBuilder.Entity<Genre>().HasData(
               new()
               {
                   GenreId = 1,
                   Name = "Skønlitteratur",
                   LeasePeriod = 30
               },
               new()
               {
                   GenreId = 2,
                   Name = "Quicklån",
                   LeasePeriod = 7
               }
               );
            modelBuilder.Entity<Nationality>().HasData(
                 new()
                 {
                     NationalityId = 1,
                     Name = "Danmark"
                 },
                 new()
                 {
                     NationalityId = 2,
                     Name = "Japan"
                 }, new()
                 {
                     NationalityId = 3,
                     Name = "Storbritanien"
                 },
                 new()
                 {
                     NationalityId = 4,
                     Name = "USA"
                 },
                 new()
                 {
                     NationalityId = 5,
                     Name = "Rusland"
                 }
                );
            modelBuilder.Entity<Author>().HasData(
                new()
                {
                    AuthorId = 1,
                    FName = "Shibiku",
                    LName = "Murasaki",
                    BYear = 973,
                    DYear = 1031,
                    NationalityId = 2
                },
                new()
                {
                    AuthorId = 2,
                    FName = "Hans",
                    MName = "Christian",
                    LName = "Andersen",
                    BYear = 1805,
                    DYear = 1875,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 3,
                    FName = "Fjodor",
                    MName = "Mikhájlovitj",
                    LName = "Dostoyevskij",
                    BYear = 1821,
                    DYear = 1881,
                    NationalityId = 5
                },
                new()
                {
                    AuthorId = 4,
                    FName = "Elsebeth",
                    LName = "Egholm",
                    BYear = 1960,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 5,
                    FName = "Hans",
                    LName = "Scherfig",
                    BYear = 1905,
                    DYear = 1979,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 6,
                    FName = "Haruki",
                    LName = "Murakami",
                    BYear = 1949,
                    NationalityId = 2
                },
                new()
                {
                    AuthorId = 7,
                    FName = "Egon",
                    LName = "Mathiesen",
                    BYear = 1907,
                    DYear= 1976,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 8,
                    FName = "Dan",
                    LName = "Abnett",
                    BYear = 1965,
                    NationalityId = 3
                },
                new()
                {
                    AuthorId = 9,
                    FName = "Tom",
                    LName = "Kristensen",
                    BYear = 1893,
                    DYear = 1974,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 10,
                    FName = "Jesper",
                    LName = "Kurt-Nielsen",
                    BYear = 1961,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 11,
                    FName = "Cormac",
                    LName = "McCarthy",
                    BYear = 1933,
                    NationalityId = 4
                },
                new()
                {
                    AuthorId = 12,
                    FName = "Camille",
                    LName = "Blomst",
                    BYear = 1972,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 13,
                    FName = "Leif",
                    MName = "Donbæk",
                    LName = "Thomsen",
                    BYear = 1984,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 14,
                    FName = "Robert",
                    MName = "Anson",
                    LName = "Heinlein",
                    BYear = 1907,
                    DYear = 1988,
                    NationalityId = 4
                },
                new()
                {
                    AuthorId = 15,
                    FName = "Hunter",
                    MName = "Stockton",
                    LName = "Thompson",
                    BYear = 1936,
                    DYear = 2006,
                    NationalityId = 4
                },
                new()
                {
                    AuthorId = 16,
                    FName = "Lev",
                    MName = "Nikolajevitj",
                    LName = "Tolstoj",
                    BYear = 1828,
                    DYear = 1910,
                    NationalityId = 5
                },
                new()
                {
                    AuthorId = 17,
                    FName = "Bret",
                    MName = "Easton",
                    LName = "Ellis",
                    BYear = 1964,
                    NationalityId = 4
                },
                new()
                {
                    AuthorId = 18,
                    FName = "Chuck",
                    LName = "Palahniuk",
                    BYear = 1962,
                    NationalityId = 4
                },
                new()
                {
                    AuthorId = 19,
                    FName = "Henning",
                    LName = "Jensen",
                    BYear = 1943,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 20,
                    FName = "Jørn",
                    LName = "Mader",
                    BYear = 1947,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 21,
                    FName = "Pablo",
                    LName = "Fenjves",
                    BYear = 1953,
                    NationalityId = 4
                },
                new()
                {
                    AuthorId = 22,
                    FName = "Erwin",
                    LName = "Neutzky-Wulff",
                    BYear = 1949,
                    NationalityId = 1
                },
                new()
                {
                    AuthorId = 23,
                    FName = "Knud",
                    LName = "Holten",
                    BYear = 1945,
                    NationalityId = 1
                }
                );

            modelBuilder.Entity<Title>().HasData(
                new()
                {
                    TitleId = 1,
                    Name = "Fortællingen om Genji",
                    RYear = 1021,
                    Pages = 224,
                    AuthorId = 1,
                    LanguageId = 3,
                    PublisherId = 1,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 2,
                    Name = "Eventyr, fortalt for Børn",
                    RYear = 1837,
                    Pages = 300,
                    AuthorId = 2,
                    LanguageId = 1,
                    PublisherId = 2,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 3,
                    Name = "Forbrydelse og Straf",
                    RYear = 1866,
                    Pages = 684,
                    AuthorId = 3,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 4,
                    Name = "Idioten",
                    RYear = 1869,
                    Pages = 843,
                    AuthorId = 3,
                    LanguageId = 2,
                    PublisherId = 1,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 5,
                    Name = "Den Røde Glente",
                    RYear = 2022,
                    Pages = 408,
                    AuthorId= 4,
                    LanguageId= 1,
                    PublisherId = 3,
                    GenreId = 2
                }, new()
                {
                    TitleId = 6,
                    Name = "Den Røde Glente",
                    RYear = 2022,
                    Pages = 408,
                    AuthorId = 4,
                    LanguageId = 1,
                    PublisherId = 3,
                    GenreId = 5
                },
                new()
                {
                    TitleId = 7,
                    Name = "Idioten",
                    RYear = 2022,
                    Pages = 843,
                    AuthorId = 4,
                    LanguageId = 4,
                    PublisherId = 3,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 8,
                    Name = "Aben Osvald",
                    RYear = 1947,
                    Pages = 48,
                    AuthorId = 7,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 4
                },
                new()
                {
                    TitleId = 9,
                    Name = "Embedded",
                    RYear = 2011,
                    Pages = 352,
                    AuthorId = 8,
                    LanguageId = 2,
                    PublisherId = 4,
                    GenreId = 6
                },                
                new()
                {
                    TitleId = 10,
                    Name = "Hard-boiled Wonderland and The End of The World",
                    RYear = 1985,
                    Pages = 618,
                    AuthorId = 6,
                    LanguageId = 3,
                    PublisherId = 3,
                    GenreId = 6
                },
                new()
                {
                    TitleId = 11,
                    Name = "Hard-boiled Wonderland and The End of The World",
                    RYear = 1991,
                    Pages = 400,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 3,
                    GenreId = 6
                },
                new()
                {
                    TitleId = 12,
                    Name = "Den Forsvundne Fuldmægtig",
                    RYear = 1938,
                    Pages = 183,
                    AuthorId = 5,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 13,
                    Name = "Det Forsømte Forår",
                    RYear = 1940,
                    Pages = 179,
                    AuthorId = 5,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 14,
                    Name = "Dammen",
                    RYear = 1958,
                    Pages = 108,
                    AuthorId = 5,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 15,
                    Name = "Hærværk",
                    RYear = 1930,
                    Pages = 430,
                    AuthorId = 9,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 16,
                    Name = "Manden der ikke ville være høflig",
                    RYear = 2020,
                    Pages = 331,
                    AuthorId = 10,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 17,
                    Name = "Man tager en alligator eller leguan af passende størrelse",
                    RYear = 2006,
                    Pages = 139,
                    AuthorId = 10,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 18,
                    Name = "No Country for Old Men",
                    RYear = 2005,
                    Pages = 320,
                    AuthorId = 11,
                    LanguageId = 2,
                    PublisherId = 5,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 19,
                    Name = "The Road",
                    RYear = 2006,
                    Pages = 287,
                    AuthorId = 11,
                    LanguageId = 2,
                    PublisherId = 5,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 20,
                    Name = "De siger man kan elske uden at få børn",
                    RYear = 2003,
                    Pages = 202,
                    AuthorId = 12,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 21,
                    Name = "Personskade - sådan sikrer du dig den erstatning, du har ret til",
                    RYear = 2019,
                    Pages = 166,
                    AuthorId = 13,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 22,
                    Name = "The Moon Is A Harsh Mistress",
                    RYear = 1966,
                    Pages = 408,
                    AuthorId = 14,
                    LanguageId = 2,
                    PublisherId = 3,
                    GenreId = 6
                },
                new()
                {
                    TitleId = 23,
                    Name = "Starship Trooper",
                    RYear = 1959,
                    Pages = 275,
                    AuthorId = 14,
                    LanguageId = 2,
                    PublisherId = 3,
                    GenreId = 6
                },
                new()
                {
                    TitleId = 24,
                    Name = "Fear and Loathing in Las Vegas",
                    RYear = 1972,
                    Pages = 204,
                    AuthorId = 15,
                    LanguageId = 2,
                    PublisherId = 3,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 25,
                    Name = "Hos Kosakkerne",
                    RYear = 1928,
                    Pages = 212,
                    AuthorId = 16,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 26,
                    Name = "Kazakh",
                    RYear = 1863,
                    Pages = 212,
                    AuthorId = 16,
                    LanguageId = 4,
                    PublisherId = 1,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 27,
                    Name = "American Psycho",
                    RYear = 1991,
                    Pages = 384,
                    AuthorId = 17,
                    LanguageId = 2,
                    PublisherId = 5,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 28,
                    Name = "Survivor",
                    RYear = 1999,
                    Pages = 304,
                    AuthorId = 18,
                    LanguageId = 2,
                    PublisherId = 5,
                    GenreId = 1
                },
                new()
                {
                    TitleId = 29,
                    Name = "Henning Jensen - En Skidt Knægt",
                    RYear = 2022,
                    Pages = 332,
                    AuthorId = 19,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 7
                },
                new()
                {
                    TitleId = 30,
                    Name = "Henning Jensen - En Skidt Knægt",
                    RYear = 2022,
                    Pages = 332,
                    AuthorId = 19,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 2
                },
                new()
                {
                    TitleId = 31,
                    Name = "Sidste tour - Mader og Leth",
                    RYear = 2022,
                    Pages = 256,
                    AuthorId = 20,
                    LanguageId = 1,
                    PublisherId = 2,
                    GenreId = 2
                },
                new()
                {
                    TitleId = 32,
                    Name = "Sidste tour - Mader og Leth",
                    RYear = 2022,
                    Pages = 256,
                    AuthorId = 20,
                    LanguageId = 1,
                    PublisherId = 2,
                    GenreId = 7
                },
                new()
                {
                    TitleId = 33,
                    Name = "If I Did It",
                    RYear = 2007,
                    Pages = 210,
                    AuthorId = 21,
                    LanguageId = 2,
                    PublisherId = 5,
                    GenreId = 7
                },
                new()
                {
                    TitleId = 34,
                    Name = "Møde",
                    RYear = 2018,
                    Pages = 497,
                    AuthorId = 22,
                    LanguageId = 1,
                    PublisherId = 5,
                    GenreId = 6
                },
                new()
                {
                    TitleId = 35,
                    Name = "Mis med de blå øjne",
                    RYear = 1949,
                    Pages = 120,
                    AuthorId = 7,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 4
                },
                new()
                {
                    TitleId = 36,
                    Name = "Blå mand - en remse til vrøvle og glæde",
                    RYear = 1956,
                    Pages = 28,
                    AuthorId = 7,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 4
                },
                new()
                {
                    TitleId = 37,
                    Name = "Kaspers rejse til de mærkelige væseners land - et eventyr for børn",
                    RYear = 1969,
                    Pages = 62,
                    AuthorId = 23,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 4
                },
                new()
                {
                    TitleId = 38,
                    Name = "Karfunkel-Jægerne : en eventyr-roman",
                    RYear = 1980,
                    Pages = 85,
                    AuthorId = 23,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 4
                }
                );
            modelBuilder.Entity<Material>().HasData(
              new()
              {
                  MaterialId = 1,
                  TitleId = 1,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 2,
                  TitleId = 1,
                  LocationId = 2,
                  Home = true
              }, 
              new()
              {
                  MaterialId = 3,
                  TitleId = 2,
                  LocationId = 1,
                  Home = true
              }, new()
              {
                  MaterialId = 4,
                  TitleId = 3,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 5,
                  TitleId = 3,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 6,
                  TitleId = 4,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 7,
                  TitleId = 5,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 8,
                  TitleId = 5,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 9,
                  TitleId = 6,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 10,
                  TitleId = 6,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 11,
                  TitleId = 7,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 12,
                  TitleId = 8,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 13,
                  TitleId = 9,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 14,
                  TitleId = 10,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 15,
                  TitleId = 10,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 16,
                  TitleId = 11,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 17,
                  TitleId = 12,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 18,
                  TitleId = 13,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 19,
                  TitleId = 14,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 20,
                  TitleId = 15,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 21,
                  TitleId = 15,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 22,
                  TitleId = 15,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 23,
                  TitleId = 16,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 24,
                  TitleId = 3,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 25,
                  TitleId = 17,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 26,
                  TitleId = 18,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 27,
                  TitleId = 19,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 28,
                  TitleId = 19,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 29,
                  TitleId = 20,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 30,
                  TitleId = 21,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 31,
                  TitleId = 22,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 32,
                  TitleId = 23,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 33,
                  TitleId = 24,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 34,
                  TitleId = 25,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 35,
                  TitleId = 25,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 36,
                  TitleId = 26,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 37,
                  TitleId = 27,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 38,
                  TitleId = 27,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 39,
                  TitleId = 28,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 40,
                  TitleId = 28,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 41,
                  TitleId = 29,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 42,
                  TitleId = 29,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 43,
                  TitleId = 30,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 44,
                  TitleId = 30,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 45,
                  TitleId = 30,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 46,
                  TitleId = 31,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 47,
                  TitleId = 32,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 48,
                  TitleId = 32,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 49,
                  TitleId = 33,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 50,
                  TitleId = 34,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 51,
                  TitleId = 35,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 52,
                  TitleId = 35,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 53,
                  TitleId = 36,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 54,
                  TitleId = 37,
                  LocationId = 1,
                  Home = true
              }
              );
        }

    }
}
    

