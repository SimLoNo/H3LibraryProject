using H3LibraryProject.API.DTOs;
using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using H3LibraryProject.Services.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3LibraryProject.Tests.ServiceTests
{
    public class LocationServiceTests
    {
        private readonly LocationService _service;
        private readonly Mock<ILocationRepository> _mockRepository = new();

        public LocationServiceTests()
        {
            _service = new(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllLocations_ShouldReturnListOfLocationResponse_WhenLocationsExist()
        {
            //Arrange
            List<Location> locationers = new()
            {
                new()
                {
                    LocationId = 1,
                    Name = "Test"
                },
                new()
                {
                    LocationId = 2,
                    Name = "Test"
                }
            };

            _mockRepository
                .Setup(x => x.GetAllLocations())
                .ReturnsAsync(locationers);
            //Act
            var result = await _service.GetAllLocations();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<LocationResponse>>(result);
            Assert.Equal(locationers.Count, result.Count);
        }
        [Fact]
        public async void GetAllLocations_ShouldReturnEmptyListOfLocations_WhenNoLocationsExist()
        {
            //Arrange
            List<Location> locationers = new();

            _mockRepository
                .Setup(x => x.GetAllLocations())
                .ReturnsAsync(locationers);
            //Act
            var result = await _service.GetAllLocations();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<LocationResponse>>(result);
            Assert.Empty(result);

        }

        [Fact]
        public async void GetLocationById_ShouldReturnLocationResponse_WhenTheLocationerExist()
        {
            //arrange
            int id = 1;
            Location location = new()
            {

                LocationId = id,
                Name = "Test"
            };

            _mockRepository
                .Setup(x => x.GetLocationById(It.IsAny<int>()))
                .ReturnsAsync(location);
            //Act
            var result = await _service.GetLocationById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LocationResponse>(result);
            Assert.Equal(id, result.LocationId);
        }

        [Fact]
        public async void GetLocationById_ShouldReturnNull_WhenTheLocationDoesNotExist()
        {
            //arrange
            int id = 1;

            _mockRepository
                .Setup(x => x.GetLocationById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.GetLocationById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateLocation_ShouldReutnrLocationResponse_WhenLocationIsCreated()
        {
            //Arrange
            int id = 1;
            Location location = new()
            {
                LocationId = id,
                Name = "Test"
            };
            LocationRequest request = new()
            {
                Name = "Test"
            };

            _mockRepository
                .Setup(x => x.CreateLocation(It.IsAny<Location>()))
                .ReturnsAsync(location);
            //Act
            var result = await _service.CreateLocation(request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LocationResponse>(result);
        }

        [Fact]
        public async void CreateLocation_ShouldReturnNUll_WhenLocationIsNotCreated()
        {
            //Arrange
            string name = "Test";
            LocationRequest request = new()
            {
                Name = "Test"
            };

            _mockRepository
                .Setup(x => x.CreateLocation(It.IsAny<Location>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.CreateLocation(request);
            //Assert
            Assert.Null(result);

        }

        [Fact]
        public async void UpdateLocation_ShouldReturnLocationResponse_WhenLocationIsUpdated()
        {
            //Arrange
            int id = 1;
            LocationRequest request = new()
            {
                Name = "Test"
            };
            Location location = new()
            {
                LocationId = id,
                Name = "test"
            };

            _mockRepository
                .Setup(x => x.UpdateLocation(It.IsAny<int>(), It.IsAny<Location>()))
                .ReturnsAsync(location);
            //Act
            var result = await _service.UpdateLocation(id, request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LocationResponse>(result);
        }


        [Fact]
        public async void UpdateLocation_ShouldReturnNull_WhenLocationIsNotUpdated()
        {
            //Arrange
            int id = 1;
            LocationRequest request = new()
            {
                Name = "Test"
            };

            _mockRepository
                .Setup(x => x.UpdateLocation(It.IsAny<int>(), It.IsAny<Location>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.UpdateLocation(id, request);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLocation_shouldReturnLocationResponse_WhenLocationIsDeleted()
        {
            //Arrange
            int id = 1;
            string name = "Test";
            Location location = new()
            {
                LocationId = id,
                Name = name
            };

            _mockRepository
                .Setup(x => x.DeleteLocation(It.IsAny<int>()))
                .ReturnsAsync(location);
            //Act
            var result = await _service.DeleteLocation(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LocationResponse>(result);
            Assert.Equal(id, result.LocationId);
        }

        [Fact]
        public async void DeleteLocation_shouldReturnNull_WhenLocationIsNotDeleted()
        {
            //Arrange
            int id = 1;
            _mockRepository
                .Setup(x => x.DeleteLocation(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.DeleteLocation(id);
            //Assert
            Assert.Null(result);

        }
    }
}
