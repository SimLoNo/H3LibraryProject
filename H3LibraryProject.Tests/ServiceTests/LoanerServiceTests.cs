using H3LibraryProject.API.DTOs;
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
    public class LoanerServiceTests
    {
        private readonly LoanerService _service;
        private readonly Mock<ILoanerRepository> _mockRepository = new();

        public LoanerServiceTests()
        {
            _service = new(_mockRepository.Object);
        }

        [Fact]
        public async void CreateLoaner_ShouldReturnLoanerResponse_whenLoanerIsCreated()
        {
            //Arrange
            int id = 1;
            Loaner loaner = new()
            {
                LoanerId = id,
                LoanerTypeId = 1,
                Name = "Test",
                Password = "Test"
            };
            LoanerRequest request = new()
            {
                LoanerTypeId = id,
                Name = "Test",
                Password = "Test"
            };

            _mockRepository
                .Setup(x => x.CreateLoaner(It.IsAny<Loaner>()))
                .ReturnsAsync(loaner);
            //Act
            var result = await _service.CreateLoaner(request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerResponse>(result);
            Assert.Equal(loaner.Name, result.LoanerName);
        }


        [Fact]
        public async void CreateLoaner_ShouldReturnNull_WhenLoanerIsNotCreated()
        {
            //Arrange
            int id = 1;
            LoanerRequest request = new()
            {
                LoanerTypeId = id,
                Name = "Test",
                Password = "Test"
            };

            _mockRepository
                .Setup(x => x.CreateLoaner(It.IsAny<Loaner>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.CreateLoaner(request);
            //Assert
            Assert. Null(result);
        }

        [Fact]
        public async void DeleteLoaner_ShouldReturnLoanerResponse_WhenLoanerIsDeleted()
        {
            //Arrange
            int id = 1;
            Loaner loaner = new()
            {
                LoanerId = id,
                LoanerTypeId = 1,
                Name = "Test",
                Password = "Test"
            };

            _mockRepository
                .Setup(x => x.DeleteLoaner(It.IsAny<int>()))
                .ReturnsAsync(loaner);
            //Act
            var result = await _service.DeleteLoaner(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerResponse>(result);
            Assert.Equal(id, result.LoanerId);
        }

        [Fact]
        public async void DeleteLoaner_ShouldReturnNull_WhenLoanerIsNotDeleted()
        {
            //Arrange
            int id = 1;

            _mockRepository
                .Setup(x => x.DeleteLoaner(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            //Act
            var result = await _service.DeleteLoaner(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void GetAllLoaners_ShouldReturnListOfLoanerResponse_WhenLoanersExist()
        {
            //Arrange
            List<Loaner> loaners = new()
            {
                new()
                {
                    LoanerId = 1,
                    LoanerTypeId = 1,
                    Name = "test",
                    Password = "Test"
                },
                new()
                {
                    LoanerId = 2,
                    LoanerTypeId = 1,
                    Name = "test",
                    Password = "Test"
                }
            };

            _mockRepository
                .Setup(l => l.GetAllLoaners())
                .ReturnsAsync(loaners);
            //Act
            var result = await _service.GetAllLoaners();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<LoanerResponse>>(result);
            Assert.Equal(loaners.Count, result.Count);
        }

        [Fact]
        public async void GetAllLoaners_ShouldReturnEmptyListOfLoanerResponse_WhenNoLoanersExist()
        {
            //Arrange
            List<Loaner> loaners = new();
            _mockRepository
                .Setup(l => l.GetAllLoaners())
                .ReturnsAsync(loaners);
            //Act
            var result = await _service.GetAllLoaners();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<LoanerResponse>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public async void GetLoanersById_ShouldReturnLoanerResponse_WhenTheLoanerExist()
        {
            //Arrange
            int id = 1;
            Loaner loaner = new()
            {
                LoanerId = id,
                Name = "test",
                LoanerTypeId = 1,
                Password = "Test"
            };

            _mockRepository
                .Setup(x => x.GetLoanerById(It.IsAny<int>()))
                .ReturnsAsync(loaner);
            //Act
            var result = await _service.GetLoanerById(id);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerResponse>(result);
            Assert.Equal(id,result.LoanerId);
        }

        [Fact]
        public async void GetLoanersById_ShouldReturnNull_WhenTheLoanerDoesNotExist()
        {
            //Arrange
            int id = 1;
            _mockRepository
                .Setup(x => x.GetLoanerById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.GetLoanerById(id);
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateLoaner_ShouldReturnLoanerResponse_WhenTheLoanerIsUpdated()
        {
            //Arrange
            int id = 1;
            LoanerRequest request = new()
            {
                Name = "test",
                LoanerTypeId = 1,
                Password = "Test"
            };
            Loaner loaner = new()
            {
                LoanerId = id,
                LoanerTypeId = 1,
                Name = "test",
                Password = "Test"
            };

            _mockRepository
                .Setup(x => x.UpdateLoaner(It.IsAny<int>(), It.IsAny<Loaner>()))
                .ReturnsAsync(loaner);
            //Act
            var result = await _service.UpdateLoaner(id, request);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<LoanerResponse>(result);
        }

        [Fact]
        public async void UpdateLoaner_ShouldReturnNull_WhenTheLoanerIsNotUpdated()
        {
            //Arrange
            int id = 1;
            LoanerRequest request = new()
            {
                Name = "test",
                LoanerTypeId = 1,
                Password = "Test"
            };

            _mockRepository
                .Setup(x => x.UpdateLoaner(It.IsAny<int>(), It.IsAny<Loaner>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _service.UpdateLoaner(id, request);
            //Assert
            Assert.Null(result);
        }

        
    }
}
