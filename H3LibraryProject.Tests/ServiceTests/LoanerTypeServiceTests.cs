using H3LibraryProject.Repositories.Database;
using H3LibraryProject.Repositories.Repositories;
using H3LibraryProject.Services.DTO;
using H3LibraryProject.Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3LibraryProject.Tests.ServiceTests
{
    public class LoanerTypeServiceTests
    {
        private readonly LoanerTypeService _service;
        private readonly Mock<ILoanerTypeRepository> _mockRepository = new();

        public LoanerTypeServiceTests()
        {
            _service = new(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllLoanerTypes_ShouldReturnListOfLoanerTypeResponse_WhenLoanerTypesExist()
        {
            //Arrange
            List<LoanerType> loaners = new()
            {
                new()
                {
                    LoanerTypeId = 1,
                    Name = "Test1"
                },
                new()
                {
                    LoanerTypeId = 2,
                    Name = "Test2"
                }
            };

            _mockRepository
                .Setup(x => x.GetAllLoanerTypes())
                .ReturnsAsync(loaners);
            //Act
            var result = await _service.GetAllLoanerTypes();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<LoanerTypeResponse>>(result);
            Assert.Equal(loaners.Count, result.Count);
        }
        [Fact]
        public async void GetAllLoanerTypes_ShouldReturnEmptyListOfLoanerTypes_WhenNoLoanerTypesExist()
        {
            //Arrange
            List<LoanerType> loaners = new();

            _mockRepository
                .Setup(x => x.GetAllLoanerTypes())
                .ReturnsAsync(loaners);
            //Act
            var result = await _service.GetAllLoanerTypes();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<LoanerTypeResponse>>(result);
            Assert.Empty(result);

        }

        [Fact]
        public async void GetLoanerTypeById_ShouldReturnLoanerTypeResponse_WhenTheLoanerExist()
        {
            //arrange
            int id = 1;
            LoanerType loanerType = new()
            {
                LoanerTypeId = id,
                Name = "Test"
            };

            _mockRepository
                .Setup(x => x.GetLoanerTypeById(It.IsAny<int>()))
                .ReturnsAsync(loanerType);
            //Act
            var result = await _service.GetLoanerTypeById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerTypeResponse>(result);
            Assert.Equal(id, result.LoanerTypeId);
        }

        [Fact]
        public async void GetLoanerTypeById_ShouldReturnNull_WhenTheLoanerTypeDoesNotExist()
        {
            //arrange
            int id = 1;

            _mockRepository
                .Setup(x => x.GetLoanerTypeById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.GetLoanerTypeById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void CreateLoanerType_ShouldReutnrLoanerTypeResponse_WhenLoanerTypeIsCreated()
        {
            //Arrange
            int id = 1;
            string name = "Test";
            LoanerType loanerType = new()
            {
                LoanerTypeId = id,
                Name = name
            };
            LoanerTypeRequest request = new()
            {
                Name = name
            };

            _mockRepository
                .Setup(x => x.CreateLoanerType(It.IsAny<LoanerType>()))
                .ReturnsAsync(loanerType);
            //Act
            var result = await _service.CreateLoanerType(request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerTypeResponse>(result);
            Assert.Equal(name, result.Name);
        }

        [Fact]
        public async void CreateLoanerType_ShouldReturnNUll_WhenLoanerTypeIsNotCreated()
        {
            //Arrange
            string name = "Test";
            LoanerTypeRequest request = new()
            {
                Name = name
            };

            _mockRepository
                .Setup(x => x.CreateLoanerType(It.IsAny<LoanerType>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.CreateLoanerType(request);
            //Assert
            Assert.Null(result);

        }

        [Fact]
        public async void UpdateLoanerType_ShouldReturnLoanerTypeResponse_WhenLoanerTypeIsUpdated()
        {
            //Arrange
            int id = 1;
            string newName = "New name!";
            LoanerTypeRequest request = new()
            {
                Name = newName
            };
            LoanerType loanerType = new()
            {
                LoanerTypeId = id,
                Name = newName
            };

            _mockRepository
                .Setup(x => x.UpdateLoanerType(It.IsAny<int>(), It.IsAny<LoanerType>()))
                .ReturnsAsync(loanerType);
            //Act
            var result = await _service.UpdateLoanerType(id, request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerTypeResponse>(result);
            Assert.Equal(newName, result.Name);
        }


        [Fact]
        public async void UpdateLoanerType_ShouldReturnNull_WhenLoanerTypeIsNotUpdated()
        {
            //Arrange
            int id = 1;
            string newName = "New name!";
            LoanerTypeRequest request = new()
            {
                Name = newName
            };

            _mockRepository
                .Setup(x => x.UpdateLoanerType(It.IsAny<int>(), It.IsAny<LoanerType>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.UpdateLoanerType(id, request);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteLoanerType_shouldReturnLoanerTypeResponse_WhenLoanerTypeIsDeleted()
        {
            //Arrange
            int id = 1;
            string name = "Test";
            LoanerType loanerType = new()
            {
                LoanerTypeId = id,
                Name = name
            };

            _mockRepository
                .Setup(x => x.DeleteLoanerType(It.IsAny<int>()))
                .ReturnsAsync(loanerType);
            //Act
            var result = await _service.DeleteLoanerType(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerTypeResponse>(result);
            Assert.Equal(id, result.LoanerTypeId);
        }

        [Fact]
        public async void DeleteLoanerType_shouldReturnNull_WhenLoanerTypeIsNotDeleted()
        {
            //Arrange
            int id = 1;
            _mockRepository
                .Setup(x => x.DeleteLoanerType(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.DeleteLoanerType(id);
            //Assert
            Assert.Null(result);

        }
    }
}
