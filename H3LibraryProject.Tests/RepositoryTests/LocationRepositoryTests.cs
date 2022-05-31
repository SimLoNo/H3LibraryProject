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
    public class LocationRepositoryTests
    {
        private readonly DbContextOptions<LibraryContext> _options;
        private readonly LibraryContext _context;
        private readonly LocationRepository _repository;

        public LocationRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryProjectLocation")
                .Options;
            _context = new(_options);

            _repository = new(_context);
        }

        [Fact]
        public async void GetAllLocations_ShouldReturnListOfLocations_WhenLocationsExist()
        {
            //Arrange
            int id = 1;
            List<Location> locationList = new()
            {
                new()
                {
                    LocationId = id,
                    Name = "Test"
                },
                new()
                {
                    LocationId = id + 1,
                    Name = "Test"
                }
            };
            await _context.Database.EnsureDeletedAsync();
            foreach (Location item in locationList)
            {
                _context.Location.Add(item);
            }
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAllLocations();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Location>>(result);
            Assert.Equal(locationList.Count, result.Count);
        }
        [Fact]
        public async void GetAllLocations_ShouldReturnEmptyListOfLocations_WhenNoLocationsExist()
        {
            //Arrange
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetAllLocations();
            //assert
            Assert.NotNull(result);
            Assert.IsType<List<Location>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetLocationById_ShouldReturnLocation_WhenTheLocationExists()
        {
            //Arrange
            int id = 1;
            Location location = new()
            {
                LocationId = id,
                Name = "Test"
            };
            await _context.Database.EnsureDeletedAsync();
            _context.Location.Add(location);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetLocationById(id);
            //assert
            Assert.NotNull(result);
            Assert.IsType<Location>(result);
            Assert.Equal(id, result.LocationId);
        }
        [Fact]
        public async void GetLocationById_ShouldReturnNull_WhenTheLocationDoesNotExist()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.GetLocationById(id);
            //assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateLocation_ShouldReturnError_WhenLocationAlreadyExist()
        {
            //Arrange
            int id = 1;
            Location location = new()
            {
                LocationId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Location.Add(location);
            await _context.SaveChangesAsync();

            //Act
            async Task action() => await _repository.CreateLocation(location);
            //Assert
            var ex = await Assert.ThrowsAsync<ArgumentException>(action);
            Assert.Contains("An item with the same key has already been added", ex.Message);
        }

        [Fact]
        public async void CreateLocationType_ShouldReturnLocationType_WhenErrorIsNotFired()
        {
            //Arrange
            Location location = new()
            {
                LocationId = 1,
                Name = "Test"
            };
            await _context.Database.EnsureDeletedAsync();

            //Act
            var result = await _repository.CreateLocation(location);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Location>(result);
        }

        [Fact]
        public async void UpdateLocatione_ShouldReturnLocation_WhenLocationIsUpdated()
        {
            //Arrange
            int id = 1;
            Location location = new()
            {
                LocationId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Location.Add(location);
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateLocation(id, location);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Location>(result);
        }

        [Fact]
        public async void UpdateLocation_ShouldReturnNull_WhenNoLocationIsUpdated()
        {
            //Arrange
            int id = 1;
            Location location = new()
            {
                LocationId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();

            //Act
            var result = await _repository.UpdateLocation(id, location);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLocatione_ShouldReturnNull_WhenNoLocationIsDeleted()
        {
            //Arrange
            int id = 1;
            await _context.Database.EnsureDeletedAsync();
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteLocation(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLocation_ShouldReturnLocation_WhenLocationIsDeleted()
        {
            //Arrange
            int id = 1;
            Location location = new()
            {
                LocationId = id,
                Name = "Test"
            };

            await _context.Database.EnsureDeletedAsync();
            _context.Location.Add(location);
            await _context.SaveChangesAsync();
            //Act
            var result = await _repository.DeleteLocation(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Location>(result);
            Assert.Equal(id, result.LocationId);

        }
    }
}
