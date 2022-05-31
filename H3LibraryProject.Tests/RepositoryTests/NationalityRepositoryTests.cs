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
    public class NationalityRepositoryTests
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private readonly LibraryContext _context;
        private readonly NationalityRepository _repository;

        public NationalityRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectNationality")
                .Options;
            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllNationalitys_ShouldReturnListOfNationalitys_WhenNationalitysExist()
        {
            //Arrange
            int id = 1;
            List<Nationality> nationalityList = new()
            {
                new()
                {
                    NationalityId = id,
                    Name = "Test"
                },
                new()
                {
                    NationalityId = id + 1,
                    Name = "Test"
                }
            };
            await _context.Database.EnsureDeletedAsync();
            foreach (Nationality item in nationalityList)
            {
                _context.Nationality.Add(item);
            }
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllNationalities();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Nationality>>(result);
            Assert.Equal(nationalityList.Count, result.Count);
        }
        [Fact]
        public async void GetAllNationalitys_ShouldReturnEmptyListOfNationalitys_WhenNoNationalitysExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectAllNationalities();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Nationality>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetNationalityById_ShouldReturnNationality_WhenTheNationalityExists()
        {
            //Arrange
            int id = 1;
            Nationality nationality = new()
            {
                NationalityId = id,
                Name = "Test"
            };
            await _context.Database.EnsureDeletedAsync();
            _context.Nationality.Add(nationality);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectNationalityById(id);
            //assert
            Assert.NotNull(result);
            Assert.IsType<Nationality>(result);
            Assert.Equal(id, result.NationalityId);
        }
        [Fact]
        public async void GetNationalityById_ShouldReturnNull_WhenTheNationalityDoesNotExist()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.SelectNationalityById(id);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateNationality_ShouldReturnError_WhenNationalityAlreadyExist()
        {
            //Arrange
            int id = 1;
            Nationality nationality = new()
            {
                NationalityId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Nationality.Add(nationality);
            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.InsertNewNationality(nationality);
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async void CreateNationalityType_ShouldReturnNationalityType_WhenErrorIsNotFired()
        {
            //Arrange
            Nationality nationality = new()
            {
                NationalityId = 1,
                Name = "Test"
            };
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _repository.InsertNewNationality(nationality);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Nationality>(result);
        }

        [Fact]
        public async void UpdateNationalitye_ShouldReturnNationality_WhenNationalityIsUpdated()
        {
            //Arrange
            int id = 1;
            Nationality nationality = new()
            {
                NationalityId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Nationality.Add(nationality);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingNationality(id, nationality);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Nationality>(result);
        }

        [Fact]
        public async void UpdateNationality_ShouldReturnNull_WhenNoNationalityIsUpdated()
        {
            //Arrange
            int id = 1;
            Nationality nationality = new()
            {
                NationalityId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateExistingNationality(id, nationality);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteNationalitye_ShouldReturnNull_WhenNoNationalityIsDeleted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteNationality(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteNationality_ShouldReturnNationality_WhenNationalityIsDeleted()
        {
            //Arrange
            int id = 1;
            Nationality nationality = new()
            {
                NationalityId = id,
                Name = "Test"


            };

            await _context.Database.EnsureDeletedAsync();
            _context.Nationality.Add(nationality);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteNationality(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Nationality>(result);
            Assert.Equal(id, result.NationalityId);

        }
    }
}
