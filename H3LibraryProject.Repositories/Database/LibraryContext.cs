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
                },
                new()
               {
                   LanguageId = 4,
                   Name = "Russisk"
               }, new()
               {
                   LanguageId = 5,
                   Name = "Hebræisk"
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
               }, new()
               {
                   GenreId = 3,
                   Name = "Faglitteratur",
                   LeasePeriod = 30
               }, new()
               {
                   GenreId = 4,
                   Name = "Børnebøger",
                   LeasePeriod = 30
               }, new()
               {
                   GenreId = 5,
                   Name = "Krimi",
                   LeasePeriod = 30
               }, new()
               {
                   GenreId = 6,
                   Name = "Sci-Fi",
                   LeasePeriod = 30
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
                    BYear = 1907,
                    DYear = 1976,
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
                    NationalityId = 5
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
                    TitleId = 7,
                    Name = "Aben Osvald",
                    RYear = 1947,
                    Pages = 33,
                    AuthorId = 7,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 4
                },
                new()
                {
                    TitleId = 8,
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
                    TitleId = 9,
                    Name = "Hard-boiled Wonderland & The End of The World",
                    RYear = 1985,
                    Pages = 618,
                    AuthorId = 6,
                    LanguageId = 3,
                    PublisherId = 3,
                    GenreId = 6
                },
                new()
                {
                    TitleId = 10,
                    Name = "Hard-boiled Wonderland & The End of The World",
                    RYear = 1991,
                    Pages = 400,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 3,
                    GenreId = 6
                },
                new()
                {
                    TitleId = 11,
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
                    TitleId = 12,
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
                    TitleId = 13,
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
                    TitleId = 14,
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
                    TitleId = 15,
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
                    TitleId = 16,
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
                    TitleId = 17,
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
                    TitleId = 18,
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
                    TitleId = 19,
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
                    TitleId = 20,
                    Name = "Personskade - sådan sikrer du dig den erstatning, du har ret til",
                    RYear = 2019,
                    Pages = 166,
                    AuthorId = 13,
                    LanguageId = 1,
                    PublisherId = 1,
                    GenreId = 3
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
                  MaterialId = 25,
                  TitleId = 18,
                  LocationId = 1,
                  Home = true
              },
              new()
              {
                  MaterialId = 25,
                  TitleId = 18,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 25,
                  TitleId = 19,
                  LocationId = 2,
                  Home = true
              },
              new()
              {
                  MaterialId = 25,
                  TitleId = 17,
                  LocationId = 1,
                  Home = true
              }
              );
        }

    }
}
    

