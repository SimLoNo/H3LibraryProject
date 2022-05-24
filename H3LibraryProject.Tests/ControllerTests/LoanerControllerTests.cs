using H3LibraryProject.API.Controllers;
using H3LibraryProject.API.DTOs;
using H3LibraryProject.Services.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3LibraryProject.Tests.ControllerTests
{
    public class LoanerControllerTests
    {
        private readonly LoanerController _controller;
        private readonly Mock<ILoanerService> _mockService = new();

        public LoanerControllerTests()
        {
            _controller = new(_mockService.Object);
        }

        [Fact]
        public async void GetAllLoaners_shouldReturnStatusCode200_WhenLoanersExist()
        {
            //Arrange
            List<LoanerResponse> response = new()
            {
                new()
                {
                    LoanerId = 1,
                    LoanerName = "Test",
                    Password = "Test"
                },
                new()
                {
                    LoanerId = 1,
                    LoanerName = "Test",
                    Password = "Test"
                }
            };

            _mockService
                .Setup(x => x.GetAllLoaners())
                .ReturnsAsync(response);
            //Act
            var result = await _controller.GetAllLoaners();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllLoaners_ShouldReturnStatusCode204_WhenLoanersDoesNotExist()
        {
            //Arrange
            List<LoanerResponse> response = new();

            _mockService
                .Setup(x => x.GetAllLoaners())
                .ReturnsAsync(response);
            //Act
            var result = await _controller.GetAllLoaners();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllLoaners_ShouldReturnStatusCode500_WhenExceptionIsFired()
        {
            //Arrange
            List<LoanerResponse> response = new();

            _mockService
                .Setup(x => x.GetAllLoaners())
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //Act
            var result = await _controller.GetAllLoaners();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetLoanerById_ShouldReturnStatusCode200_whenTheLoanerExist()
        {
            //Arrange
            int id = 1;
            LoanerResponse response = new()
            {
                LoanerId = 1,
                LoanerName = "Test",
                Password = "Test"
            };

            _mockService
                .Setup(x => x.GetLoanerById(It.IsAny<int>()))
                .ReturnsAsync(response);
            //Act
            var result = await _controller.GetLoanerById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetLoanerById_ShouldReturnStatusCode404_WhenTheLoanerDoesNotExist()
        {
            //Arrange
            int id = 1;
            _mockService
                .Setup(x => x.GetLoanerById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _controller.GetLoanerById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetLoanerById_ShouldReturnStatusCode500_WhenExceptionIsFired()
        {

            //Arrange
            int id = 1;
            _mockService
                .Setup(x => x.GetLoanerById(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //Act
            var result = await _controller.GetLoanerById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void CreateLoaner_ShouldReturnStatusCode200_whenLoanerIsCreated()
        {
            //Arrange
            LoanerRequest request = new()
            {
                Name = "Test"
            };
            LoanerResponse response = new()
            {
                LoanerId = 1,
                LoanerName = "Test",
                Password = "Test"
            };

            _mockService
                .Setup(x => x.CreateLoaner(It.IsAny<LoanerRequest>()))
                .ReturnsAsync(response);
            //Act
            var result = await _controller.CreateLoaner(request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void CreateLoaner_ShouldReturnStatusCode404_WhenLoanerIsNotCreated()
        {
            //Arrange
            LoanerRequest request = new()
            {
                Name = "Test"
            };

            _mockService
                .Setup(x => x.CreateLoaner(It.IsAny<LoanerRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _controller.CreateLoaner(request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void CreateLoaner_ShouldReturnStatusCode500_WhenExceptionIsFired()
        {
            //Arrange
            LoanerRequest request = new()
            {
                Name = "Test"
            };

            _mockService
                .Setup(x => x.CreateLoaner(It.IsAny<LoanerRequest>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //Act
            var result = await _controller.CreateLoaner(request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);


        }

        [Fact]
        public async void UpdateLoaner_ShouldReturnStatusCode200_WhenLoanerIsUpdated()
        {
            //Arrange
            int id = 1;
            LoanerRequest request = new()
            {
                Name = "Test"
            };
            LoanerResponse response = new()
            {
                LoanerId = 1,
                LoanerName = "Test",
                Password = "Test"
            };

            _mockService
                .Setup(x => x.UpdateLoaner(It.IsAny<int>(), It.IsAny<LoanerRequest>()))
                .ReturnsAsync(response);
            //Act
            var result = await _controller.UpdateLoaner(id, request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateLoaner_ShouldReturnStatusCode404_WhenTheRequestedLoanerIsNotFound()
        {
            //Arrange
            int id = 1;
            LoanerRequest request = new()
            {
                Name = "Test"
            };

            _mockService
                .Setup(x => x.UpdateLoaner(It.IsAny<int>(), It.IsAny<LoanerRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _controller.UpdateLoaner(id, request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateLoaner_ShouldReturnStatusCode400_WhenProvidedIdIsEqualToOrBelowZero()
        {
            //Arrange
            int id = 0;
            LoanerRequest request = new()
            {
                Name = "Test"
            };
            //Act
            var result = await _controller.UpdateLoaner(id, request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(400, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateLoaner_shouldReturnStatusCode500_WhenAnExceptionIsFired()
        {
            //Arrange
            int id = 1;
            LoanerRequest request = new()
            {
                Name = "Test"
            };

            _mockService
                .Setup(x => x.UpdateLoaner(It.IsAny<int>(), It.IsAny<LoanerRequest>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));

            //Act
            var result = await _controller.UpdateLoaner(id, request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteLoaner_ShouldReturnStatusCode200_WhenLoanerIsDeleted()
        {
            //Arrange
            int id = 1;
            LoanerResponse response = new()
            {
                LoanerId = 1,
                LoanerName = "Test",
                Password = "Test"
            };

            _mockService
                .Setup(x => x.DeleteLoaner(It.IsAny<int>()))
                .ReturnsAsync(response);
            //Act
            var result = await _controller.DeleteLoaner(id);
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteLoaner_ShouldReturnStatusCode404_WhenLoanerIsNotDeleted()
        {
            //Arrange
            int id = 1;

            _mockService
                .Setup(x => x.DeleteLoaner(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _controller.DeleteLoaner(id);
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteLoaner_ShouldReturnStatusCode500_WhenExceptionIsFired()
        {
            //Arrange
            int id = 1;

            _mockService
                .Setup(x => x.DeleteLoaner(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //Act
            var result = await _controller.DeleteLoaner(id);
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }
    }
}
