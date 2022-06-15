using H3LibraryProject.API.Controllers;
using H3LibraryProject.Services.DTO;
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
    public class LoanerTypeControllerTests
    {
        private readonly LoanerTypeController _controller;
        private readonly Mock<ILoanerTypeService> _mockService = new();

        public LoanerTypeControllerTests()
        {
            _controller = new(_mockService.Object);
        }

        [Fact]
        public async void GetAllLoanerTypes_shouldReturnStatusCode200_WhenLoanerTypesExist()
        {
            //Arrange
            List<LoanerTypeResponse> response = new()
            {
                new()
                {
                    LoanerTypeId = 1,
                    Name = "Test"
                },
                new()
                {
                    LoanerTypeId = 2,
                    Name = "Test2"
                }
            };

            _mockService
                .Setup(x => x.GetAllLoanerTypes())
                .ReturnsAsync(response);
            //Act
            var result = await _controller.GetAllLoanerTypes();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllLoanerTypes_ShouldReturnStatusCode204_WhenLoanerTypesDoesNotExist()
        {
            //Arrange
            List<LoanerTypeResponse> response = new();

            _mockService
                .Setup(x => x.GetAllLoanerTypes())
                .ReturnsAsync(response);
            //Act
            var result = await _controller.GetAllLoanerTypes();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(204, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetAllLoanerTypes_ShouldReturnStatusCode500_WhenExceptionIsFired()
        {
            //Arrange
            List<LoanerTypeResponse> response = new();

            _mockService
                .Setup(x => x.GetAllLoanerTypes())
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //Act
            var result = await _controller.GetAllLoanerTypes();
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetLoanerTypeById_ShouldReturnStatusCode200_whenTheLoanerTypeExist()
        {
            //Arrange
            int id = 1;
            LoanerTypeResponse response = new()
            {
                LoanerTypeId = id,
                Name = "Test"
            };

            _mockService
                .Setup(x => x.GetLoanerTypeById(It.IsAny<int>()))
                .ReturnsAsync(response);
            //Act
            var result = await _controller.GetLoanerTypeById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void GetLoanerTypeById_ShouldReturnStatusCode404_WhenTheLoanerTypeDoesNotExist()
        {
            //Arrange
            int id = 1;
            _mockService
                .Setup(x => x.GetLoanerTypeById(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _controller.GetLoanerTypeById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void GetLoanerTypeById_ShouldReturnStatusCode500_WhenExceptionIsFired()
        {

            //Arrange
            int id = 1;
            _mockService
                .Setup(x => x.GetLoanerTypeById(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //Act
            var result = await _controller.GetLoanerTypeById(id);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void CreateLoanerType_ShouldReturnStatusCode200_whenLoanerTypeIsCreated()
        {
            //Arrange
            LoanerTypeRequest request = new()
            {
                Name = "Test"
            };
            LoanerTypeResponse response = new()
            {
                LoanerTypeId = 1,
                Name = "Test"
            };

            _mockService
                .Setup(x => x.CreateLoanerType(It.IsAny<LoanerTypeRequest>()))
                .ReturnsAsync(response);
            //Act
            var result = await _controller.CreateLoanerType(request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void CreateLoanerType_ShouldReturnStatusCode404_WhenLoanerTypeIsNotCreated()
        {
            //Arrange
            LoanerTypeRequest request = new()
            {
                Name = "Test"
            };

            _mockService
                .Setup(x => x.CreateLoanerType(It.IsAny<LoanerTypeRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _controller.CreateLoanerType(request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);

        }

        [Fact]
        public async void CreateLoanerType_ShouldReturnStatusCode500_WhenExceptionIsFired()
        {
            //Arrange
            LoanerTypeRequest request = new()
            {
                Name = "Test"
            };

            _mockService
                .Setup(x => x.CreateLoanerType(It.IsAny<LoanerTypeRequest>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //Act
            var result = await _controller.CreateLoanerType(request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);


        }

        [Fact]
        public async void UpdateLoanerType_ShouldReturnStatusCode200_WhenLoanerTypeIsUpdated()
        {
            //Arrange
            int id = 1;
            LoanerTypeRequest request = new()
            {
                Name = "Test"
            };
            LoanerTypeResponse response = new()
            {
                LoanerTypeId = id,
                Name = "Test"
            };

            _mockService
                .Setup(x => x.UpdateLoanerType(It.IsAny<int>(), It.IsAny<LoanerTypeRequest>()))
                .ReturnsAsync(response);
            //Act
            var result = await _controller.UpdateLoanerType(id, request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateLoanerType_ShouldReturnStatusCode404_WhenTheRequestedLoanerTypeIsNotFound()
        {
            //Arrange
            int id = 1;
            LoanerTypeRequest request = new()
            {
                Name = "Test"
            };

            _mockService
                .Setup(x => x.UpdateLoanerType(It.IsAny<int>(), It.IsAny<LoanerTypeRequest>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _controller.UpdateLoanerType(id, request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateLoanerType_ShouldReturnStatusCode400_WhenProvidedIdIsEqualToOrBelowZero()
        {
            //Arrange
            int id = 0;
            LoanerTypeRequest request = new()
            {
                Name = "Test"
            };
            //Act
            var result = await _controller.UpdateLoanerType(id, request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(400, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void UpdateLoanerType_shouldReturnStatusCode500_WhenAnExceptionIsFired()
        {
            //Arrange
            int id = 1;
            LoanerTypeRequest request = new()
            {
                Name = "Test"
            };

            _mockService
                .Setup(x => x.UpdateLoanerType(It.IsAny<int>(), It.IsAny<LoanerTypeRequest>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            
            //Act
            var result = await _controller.UpdateLoanerType(id, request);
            //Assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteLoanerType_ShouldReturnStatusCode200_WhenLoanerTypeIsDeleted()
        {
            //Arrange
            int id = 1;
            LoanerTypeResponse response = new()
            {
                LoanerTypeId = id,
                Name = "Test"
            };

            _mockService
                .Setup(x => x.DeleteLoanerType(It.IsAny<int>()))
                .ReturnsAsync(response);
            //Act
            var result = await _controller.DeleteLoanerType(id);
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(200, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteLoanerType_ShouldReturnStatusCode404_WhenLoanerTypeIsNotDeleted()
        {
            //Arrange
            int id = 1;

            _mockService
                .Setup(x => x.DeleteLoanerType(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            var result = await _controller.DeleteLoanerType(id);
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }

        [Fact]
        public async void DeleteLoanerType_ShouldReturnStatusCode500_WhenExceptionIsFired()
        {
            //Arrange
            int id = 1;

            _mockService
                .Setup(x => x.DeleteLoanerType(It.IsAny<int>()))
                .ReturnsAsync(() => throw new Exception("This is an exception"));
            //Act
            var result = await _controller.DeleteLoanerType(id);
            //assert
            var statusCodeResult = (IStatusCodeActionResult)result;
            Assert.Equal(500, statusCodeResult.StatusCode);

        }
    }
}
