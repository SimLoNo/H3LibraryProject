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
                   Name = "Macmilan"
               },
               new()
               {
                   PublisherId = 5,
                   Name = "Vikung Press"
               },
               new()
               {
                   PublisherId = 6,
                   Name = "Delacorte Books"
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
               },
               new()
               {
                   GenreId = 3,
                   Name = "Historisk fiktion",
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
                    FName = "Ken",
                    LName = "Follet",
                    BYear = 1949,
                    NationalityId = 3
                },
                new()
                {
                    AuthorId = 6,
                    FName = "Dianna",
                    LName = "Gabaldon",
                    BYear = 1952,
                    NationalityId = 4
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
                },
                new()
                {
                    TitleId = 6,
                    Name = "Pillars of the Earth",
                    RYear = 1989,
                    Pages = 806,
                    AuthorId = 5,
                    LanguageId = 2,
                    PublisherId = 4,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 7,
                    Name = "World Without End",
                    RYear = 2007,
                    Pages = 1024,
                    AuthorId = 5,
                    LanguageId = 2,
                    PublisherId = 4,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 8,
                    Name = "A column of Fire",
                    RYear = 2017,
                    Pages = 804,
                    AuthorId = 5,
                    LanguageId = 2,
                    PublisherId = 5,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 9,
                    Name = "The Evening and the Morning",
                    RYear = 2020,
                    Pages = 832,
                    AuthorId = 5,
                    LanguageId = 2,
                    PublisherId = 4,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 10,
                    Name = "Outlander",
                    RYear = 1991,
                    Pages = 850,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 6,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 11,
                    Name = "Dragonfly in Amber",
                    RYear = 1992,
                    Pages = 752,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 6,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 12,
                    Name = "Voyager",
                    RYear = 1993,
                    Pages = 870,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 6,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 13,
                    Name = "Drums of Autumn",
                    RYear = 1996,
                    Pages = 880,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 6,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 14,
                    Name = "The Fiery Cross",
                    RYear = 2001,
                    Pages = 992,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 6,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 15,
                    Name = "A Breath of Snow and Ashes",
                    RYear = 2005,
                    Pages = 1157,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 6,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 16,
                    Name = "An Echo in the Bone",
                    RYear = 2009,
                    Pages = 820,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 6,
                    GenreId = 3
                },
                new()
                {
                    TitleId = 17,
                    Name = "Written in My Own Heart's Blood",
                    RYear = 2014,
                    Pages = 825,
                    AuthorId = 6,
                    LanguageId = 2,
                    PublisherId = 6,
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
              }
              );
        }

    }
}
    

