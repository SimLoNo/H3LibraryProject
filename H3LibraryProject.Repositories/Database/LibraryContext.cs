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
    

