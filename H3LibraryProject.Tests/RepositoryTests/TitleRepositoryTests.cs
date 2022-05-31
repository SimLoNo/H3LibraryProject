using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3LibraryProject.Tests.RepositoryTests
{
    public class TitleRepositoryTests
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private readonly LibraryContext _context;
        private readonly TitleRepository _repository;

        public TitleRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectTitle")
                .Options;
            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllTitles_ShouldReturnListOfTitles_WhenTitlesExist()
        {
            //Arrange
            int id = 1;
            List<Title> titleList = new()
            {
                new()
                {
                    TitleId = id,
                    Name = "Test"
                },
                new()
                {
                    TitleId = id + 1,
                    Name = "Test"
                }
            };
            await _context.Database.EnsureDeletedAsync();
            foreach (Title item in titleList)
            {
                _context.Title.Add(item);
            }
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllTitles();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Title>>(result);
            Assert.Equal(titleList.Count, result.Count);
        }
        [Fact]
        public async void GetAllTitles_ShouldReturnEmptyListOfTitles_WhenNoTitlesExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllTitles();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Title>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetTitleById_ShouldReturnTitle_WhenTheTitleExists()
        {
            //Arrange
            int id = 1;
            Title title = new()
            {
                TitleId = id,
                Name = "Test"
            };
            await _context.Database.EnsureDeletedAsync();
            _context.Title.Add(title);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectTitleById(id);
            //assert
            Assert.NotNull(result);
            Assert.IsType<Title>(result);
            Assert.Equal(id, result.TitleId);
        }
        [Fact]
        public async void GetTitleById_ShouldReturnNull_WhenTheTitleDoesNotExist()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectTitleById(id);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateTitle_ShouldReturnError_WhenTitleAlreadyExist()
        {
            //Arrange
            int id = 1;
            Title title = new()
            {
                TitleId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Title.Add(title);
            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.InsertNewTitle(title);
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async void CreateTitleType_ShouldReturnTitleType_WhenErrorIsNotFired()
        {
            //Arrange
            Title title = new()
            {
                TitleId = 1,
                Name = "Test"
            };
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _repository.InsertNewTitle(title);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Title>(result);
        }

        [Fact]
        public async void UpdateTitlee_ShouldReturnTitle_WhenTitleIsUpdated()
        {
            //Arrange
            int id = 1;
            Title title = new()
            {
                TitleId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Title.Add(title);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingTitle(id, title);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Title>(result);
        }

        [Fact]
        public async void UpdateTitle_ShouldReturnNull_WhenNoTitleIsUpdated()
        {
            //Arrange
            int id = 1;
            Title title = new()
            {
                TitleId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingTitle(id, title);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteTitlee_ShouldReturnNull_WhenNoTitleIsDeleted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteTitle(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteTitle_ShouldReturnTitle_WhenTitleIsDeleted()
        {
            //Arrange
            int id = 1;
            Title title = new()
            {
                TitleId = id,
                Name = "Test"


            };

            await _context.Database.EnsureDeletedAsync();
            _context.Title.Add(title);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteTitle(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Title>(result);
            Assert.Equal(id, result.TitleId);

        }
    }
}
