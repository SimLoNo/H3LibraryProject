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
    public class NationalityServiceTests
    {
        private readonly NationalityService _service;
        private readonly Mock<INationalityRepository> _mockRepository = new();

        public NationalityServiceTests()
        {
            _service = new(_mockRepository.Object);
        }

        [Fact]
        public async void CreateNationality_ShouldReturnNationalityResponse_whenNationalityIsCreated()
        {
            //Arrange
            int id = 1;
            Nationality nationality = new()
            {
                NationalityId = id,
                Name = "Test"
            };
            NationalityRequest request = new()
            {
                Name = "Test",
            };

            _mockRepository
                .Setup(x => x.InsertNewNationality(It.IsAny<Nationality>()))
                .ReturnsAsync(nationality);
            //Act
            var result = await _service.CreateNationality(request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NationalityResponse>(result);
        }


        [Fact]
        public async void CreateNationality_ShouldReturnNull_WhenNationalityIsNotCreated()
        {
            //Arrange
            NationalityRequest request = new()
            {
                Name = "Test",
            };

            _mockRepository
                .Setup(x => x.InsertNewNationality(It.IsAny<Nationality>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.CreateNationality(request);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteNationality_ShouldReturnNationalityResponse_WhenNationalityIsDeleted()
        {
            //Arrange
            int id = 1;
            Nationality nationality = new()
            {
                NationalityId = id,
                Name = "Test"
            };

            _mockRepository
                .Setup(x => x.DeleteNationality(It.IsAny<int>()))
                .ReturnsAsync(nationality);
            //Act
            var result = await _service.DeleteNationality(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NationalityResponse>(result);
            Assert.Equal(id, result.NationalityId);
        }

        [Fact]
        public async void DeleteNationality_ShouldReturnNull_WhenNationalityIsNotDeleted()
        {
            //Arrange
            int id = 1;

            _mockRepository
                .Setup(x => x.DeleteNationality(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _service.DeleteNationality(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetAllNationalitys_ShouldReturnListOfNationalityResponse_WhenNationalitysExist()
        {
            //Arrange
            int id = 1;
            List<Nationality> nationalitys = new()
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

            _mockRepository
                .Setup(l => l.SelectAllNationalities())
                .ReturnsAsync(nationalitys);
            //Act
            var result = await _service.GetAllNationalitys();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<NationalityResponse>>(result);
            Assert.Equal(nationalitys.Count, result.Count);
        }

        [Fact]
        public async void GetAllNationalitys_ShouldReturnEmptyListOfNationalityResponse_WhenNoNationalitysExist()
        {
            //Arrange
            List<Nationality> nationalitys = new();
            _mockRepository
                .Setup(l => l.SelectAllNationalities())
                .ReturnsAsync(nationalitys);
            //Act
            var result = await _service.GetAllNationalitys();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<NationalityResponse>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetNationalitysById_ShouldReturnNationalityResponse_WhenTheNationalityExist()
        {
            //Arrange
            int id = 1;
            Nationality nationality = new()
            {
                NationalityId = id,
                Name = "Test"
            };

            _mockRepository
                .Setup(x => x.SelectNationalityById(It.IsAny<int>()))
                .ReturnsAsync(nationality);
            //Act
            var result = await _service.GetNationalityById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NationalityResponse>(result);
            Assert.Equal(id, result.NationalityId);
        }

        [Fact]
        public async void GetNationalitysById_ShouldReturnNull_WhenTheNationalityDoesNotExist()
        {
            //Arrange
            int id = 1;
            _mockRepository
                .Setup(x => x.SelectNationalityById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.GetNationalityById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateNationality_ShouldReturnNationalityResponse_WhenTheNationalityIsUpdated()
        {
            //Arrange
            int id = 1;
            NationalityRequest request = new()
            {
                Name = "Test",
            };
            Nationality nationality = new()
            {
                NationalityId = id,
                Name = "Test"
            };

            _mockRepository
                .Setup(x => x.UpdateExistingNationality(It.IsAny<int>(), It.IsAny<Nationality>()))
                .ReturnsAsync(nationality);
            //Act
            var result = await _service.UpdateNationality(id, request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NationalityResponse>(result);
        }

        [Fact]
        public async void UpdateNationality_ShouldReturnNull_WhenTheNationalityIsNotUpdated()
        {
            //Arrange
            int id = 1;
            NationalityRequest request = new()
            {
                Name = "Test",
            };

            _mockRepository
                .Setup(x => x.UpdateExistingNationality(It.IsAny<int>(), It.IsAny<Nationality>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.UpdateNationality(id, request);
            //Assert
            Assert.Null(result);
        }
    }
}
