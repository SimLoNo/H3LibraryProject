using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using H3LibraryProject.Repositories.Database.Models;

namespace H3LibraryProject.Tests.RepositoryTests
{
    public class AuthorRepositoryTests
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private readonly LibraryContext _context;
        private readonly AuthorRepository _repository;

        public AuthorRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectAuthor") //vi "chainer" en metode på
                .Options;

            _context = new(_options);

            _repository = new(_context);
            //af en eller anden grund havde jeg = new AuthorRepository (_context); stående...
            //tror det virker bedre sådan her
        }

        //Create
        [Fact]
        public async void InsertNewAuthor_ShouldAddIdToAuthor_AndReturnAuthor_WhenSavingToDatabase()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int expectedNewId = 1;
            int nationalityId = 1;
            Nationality nationality = new() { NationalityId = nationalityId, Name = "Nation" };

            Author author = new()
            {
                FName = "Aage",
                MName = "Tom",
                LName = "Kristensen",
                BYear = 1893,
                NationalityId = nationalityId,
                Titles = new()
            };

            _context.Nationality.Add(nationality);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.CreateAuthor(author);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Author>(result);
            Assert.Equal(expectedNewId, result.AuthorId);
        }
        //En af følgende er redundante. Men jeg sletter ikke nogen af dem. LOL.
        [Fact]
        public async void InsertNewAuthor_ShouldThrowException_WhenTryingToAddAuthorWithAnExistingId()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            int nationalityId = 1;
            Nationality nationality = new() { NationalityId = nationalityId, Name = "Nation" };

            Author author = new()
            {
                AuthorId = 1,
                FName = "Aage",
                MName = "Tom",
                LName = "Kristensen",
                BYear = 1893,
                NationalityId = nationalityId,
                Titles = new()
            };

            _context.Nationality.Add(nationality);
            _context.Author.Add(author);
            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.CreateAuthor(author);

            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);

            Assert.Contains("An item with the same key has already been added.", ex.Message);
        }
        [Fact]
        public async void InsertNewAuthor_ShouldFailToAdd_WhenAuthorIDAlreadyExists()
        {
            //Arrange

            await _context.Database.EnsureDeletedAsync(); //Tømmer listen

            int authorId = 100;
            int nationalityId = 1;
            Nationality nationality = new() { NationalityId = nationalityId, Name = "Nation" };


            Author author = new()
            { AuthorId = authorId, 
              FName = "Aage",
              MName = "Tom",
              LName = "Kristensen",
              BYear = 1893,
              NationalityId = nationalityId,
              Titles = new()
            };


            _context.Nationality.Add(nationality);
            _context.Author.Add(author); //Heri opstår (forhåbentlig) problemet; man må ikke kunne oprette den samme flere gange



            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.CreateAuthor(author);

            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        //Read
        [Fact]
        public async void SelectAllAuthors_ShouldReturnListOfAuthors_WhemAuthorsExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync(); //Funktion, der ryder ud, så vi tester på nyt emne


            int nationalityId = 1;
            Nationality nationality = new() { NationalityId = nationalityId, Name = "Nation" };

            _context.Nationality.Add(nationality);
            _context.Author.Add(new()
            { 
                AuthorId = 100,
                FName = "Aage",
                MName = "Tom",
                LName = "Kristensen",
                BYear = 1893,
                NationalityId = nationalityId,
                Titles = new()
            });
            _context.Author.Add(new()
            { 
                AuthorId = 101,
                FName = "Hans",
                MName = "Christian", 
                LName = "Scherfig", 
                BYear = 1905,
                NationalityId = nationalityId,
                Titles = new()
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAllAuthors();

            //Assert
            Assert.NotNull(result); //Er der et antal?
            Assert.IsType<List<Author>>(result); //Er typen "Author"?
            Assert.Equal(2, result.Count); //bare lige for at tælle, at der er de to, der skal være
        }
        [Fact]
        public async void SelectAllAuthors_ShouldReturnEmptyListOfAuthors_WhemNoAuthorsExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync(); //Tømmer listen

            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAllAuthors();

            //Assert
            Assert.NotNull(result); //Den må ikke være null - den skal eksistere.
            Assert.IsType<List<Author>>(result); //Er typen "Author"?
            Assert.Empty(result); //bare lige for at sikre, at den er tom


        }
        [Fact]
        public async void SelectAuthorById_ShouldReturnAuthor_WhenAuthorExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync(); //Tømmer listen

            int authorId = 100;
            int nationalityId = 1;
            Nationality nationality = new() { NationalityId = nationalityId, Name = "Nation" };

            _context.Nationality.Add(nationality);
            _context.Author.Add(new()
            { 
                AuthorId = authorId, 
                FName = "Aage", 
                MName = "Tom", 
                LName = "Kristensen", 
                BYear = 1893,
                NationalityId = nationalityId,
                Titles = new()
            });

            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAuthorById(authorId);

            //Assert
            Assert.NotNull(result); //Er der et antal?
            Assert.IsType<Author>(result); //Er typen "Author"?
            Assert.Equal(authorId, result.AuthorId); //Er den anførte ID lig med ID'en fra resultatet?
        }
        [Fact]
        public async void SelectAuthorById_ShouldReturnNull_WhenAuthorDoesNotExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync(); //Tømmer listen

            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAuthorById(1); //Det er lige meget hvad vi leder efter; det findes ikke

            //Assert
            Assert.Null(result); //Er den null?
        }

        //Update
        [Fact]
        public async void UpdateExistingAuthor_ShouldChangeValuesOnAuthor_WhenAuthorExists()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync(); //Tømmer listen

            int authorId = 100;
            int nationalityId = 1;
            Nationality nationality = new() { NationalityId = nationalityId, Name = "Nation" };

            Author newAuthor = new()
            { 
                AuthorId = authorId,
                FName = "Aage", 
                MName = "Tom", 
                LName = "Kristensen", 
                BYear = 1893, 
                DYear = 1976,
                NationalityId = nationalityId,
                Titles = new()
            };

            _context.Nationality.Add(nationality);
            _context.Author.Add(newAuthor);
            await _context.SaveChangesAsync();

            Author updateAuthor = new()
            { 
                AuthorId = authorId,
                FName = "Henrik", 
                MName = "Johan", 
                LName = "Ibsen", 
                BYear = 1828, 
                DYear = 1906,
                NationalityId = nationalityId,
                Titles = new()
            };


            //Act
            var result = await _repository.UpdateExistingAuthor(authorId, updateAuthor);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Author>(result);
            Assert.Equal(authorId, result.AuthorId);
            Assert.Equal(updateAuthor.FName, result.FName);
            Assert.Equal(updateAuthor.MName, result.MName);
            Assert.Equal(updateAuthor.LName, result.LName);
            Assert.Equal(updateAuthor.BYear, result.BYear);
            Assert.Equal(updateAuthor.DYear, result.DYear);
        }
        [Fact]
        public async void UpdateExistingAuthor_ShouldReturnNull_WhenAuthorDoesNotExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync(); //Tømmer listen

            int authorId = 1;

            Author updateAuthor = new()
            {
                AuthorId = authorId, FName = "Henrik", MName = "Johan", LName = "Ibsen", BYear = 1828, DYear = 1906 };

            //Act
            var result = await _repository.UpdateExistingAuthor(authorId, updateAuthor);

            //Assert
            Assert.Null(result);

        }

        //Delete
        [Fact]
        public async void DeleteAuthorById_ShouldReturnDeletedAuthor_WhenAuthorIsDeleted()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            int authorId = 1;

            Author newAuthor = new()
            {
                AuthorId = authorId,
                FName = "Klaus",
                MName = null,
                LName = "Rifbjerg",
                BYear = 1931,
                DYear = 2015
            };

            _context.Author.Add(newAuthor);
            await _context.SaveChangesAsync();


            //Act
            var result = await _repository.DeleteAuthorById(authorId);
            var author = await _repository.GetAuthorById(authorId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Author>(result);
            Assert.Equal(authorId, result.AuthorId);
            Assert.Null(author);
        }
        [Fact]
        public async void DeleteAuthorById_ShouldReturnNull_WhenAuthorDoesNotExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _repository.DeleteAuthorById(1);

            //Assert
            Assert.Null(result);
        }

    }
}
