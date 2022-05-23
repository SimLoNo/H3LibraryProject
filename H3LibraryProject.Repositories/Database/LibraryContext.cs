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
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Loaner> Loaners { get; set; }
        public DbSet<LoanerType> LoanerTypes { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Title> Title { get; set; }
    }
}
